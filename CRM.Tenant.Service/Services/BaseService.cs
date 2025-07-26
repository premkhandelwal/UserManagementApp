using AutoMapper;
using FluentValidation;
using Crm.Tenant.Data.Repositories;
using Crm.Tenant.Data.Models;
using System.Linq.Expressions;
using Crm.Tenant.Data;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

public class BaseService<TRequest, TEntity>
    where TRequest : class
    where TEntity : BaseModelClass
{
    private readonly IMapper _mapper;
    private readonly BaseRepository<TEntity> _repository;
    private readonly IValidator<TRequest> _validator;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor;


    public BaseService(
        IMapper mapper,
        BaseRepository<TEntity> repository,
        IValidator<TRequest> validator,
        IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor
        ) 
    {
        _mapper = mapper;
        _repository = repository;
        _validator = validator;
        _unitOfWork = unitOfWork;
        _httpContextAccessor = httpContextAccessor;
    }

    public string? GetUserNameFromToken()
    {
        var user = _httpContextAccessor.HttpContext?.User;

        if (user == null || user.Identity == null || !user.Identity.IsAuthenticated)
            return null;

        return user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
    }


    public virtual async Task<TEntity?> CreateAsync(TRequest request)
    {
        var _userName = GetUserNameFromToken();
        ValidateRequest(request);
        TEntity entity = _mapper.Map<TEntity>(request);
        entity.AddedBy = _userName;
        entity.ModifiedBy = _userName;
        entity.AddedOn = DateTime.Now;
        entity.ModifiedOn = DateTime.Now;

        await _repository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<TEntity?> UpdateAsync(TRequest request)
    {
        var _userName = GetUserNameFromToken();
        ValidateRequest(request);
        TEntity entity = _mapper.Map<TEntity>(request);
        entity.ModifiedBy = _userName;
        entity.ModifiedOn = DateTime.Now;
        _repository.UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync(); // 🔹 Commit changes
        await _repository.ReloadAsync(entity);
        return entity;
    }

    public virtual async Task<TEntity?> DeleteAsync(TRequest request)
    {
        var _userName = GetUserNameFromToken();
        ValidateRequest(request);
        TEntity entity = _mapper.Map<TEntity>(request);
        entity.ModifiedBy = _userName;
        entity.ModifiedOn = DateTime.Now;
        bool hasReferences = await HasReferences(entity);
        if (hasReferences)
        {
            throw new InvalidOperationException("The entity cannot be deleted because it is referenced by other entities.");
        }
        entity.IsDeleted = true;
        _repository.DeleteAsync(entity);
        await _unitOfWork.SaveChangesAsync(); // 🔹 Commit changes
        await _repository.ReloadAsync(entity);
        return entity;
    }

    public virtual async Task<TEntity?> HardDeleteAsync(TRequest request)
    {
        TEntity entity = _mapper.Map<TEntity>(request);
        await _repository.HardDeleteAsync(entity);
        await _unitOfWork.SaveChangesAsync(); // 🔹 Commit changes
        await _repository.ReloadAsync(entity);
        return entity;
    }

    public virtual async Task<List<TEntity>> ReadAsync(bool fetchDeletedRecords = false, bool orderByModifiedOn = true)
    {
        return await _repository.ReadAsync(fetchDeletedRecords, orderByModifiedOn);
    }

    public virtual TEntity? GetById(int id)
    {
        return _repository.GetById(id);
    }

    private void ValidateRequest(TRequest request)
    {
        var validationResult = _validator.Validate(request);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.ToString());
        }
    }

    public virtual async Task<bool> HasReferences(TEntity entity)
    {
        await Task.Delay(0);
        return false;
    }

    public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _repository.ExistsAsync(predicate);
    }
}
