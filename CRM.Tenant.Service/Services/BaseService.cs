using AutoMapper;
using FluentValidation;
using Crm.Tenant.Data.Repositories;
using Crm.Tenant.Data.Models;

public  class BaseService<TRequest, TEntity> 
    where TRequest : class
    where TEntity : BaseModelClass
{
    
    private readonly IMapper _mapper;
    private readonly BaseRepository<TEntity> _repository;
    private readonly IValidator<TRequest> _validator;

    public BaseService(IMapper mapper, BaseRepository<TEntity> repository, IValidator<TRequest> validator)
    {   
        _mapper = mapper;
        _repository = repository;
        _validator = validator;
    }

    public virtual async Task<TEntity?> CreateAsync(TRequest request)
    {
        ValidateRequest(request);
        TEntity entity = _mapper.Map<TEntity>(request);
        return await _repository.AddAsync(entity);
    }

    public virtual async Task<TEntity?> UpdateAsync(TRequest request)
    {
        ValidateRequest(request);
        TEntity entity = _mapper.Map<TEntity>(request);
        return await _repository.UpdateAsync(entity);
    }

    public virtual async Task<TEntity?> DeleteAsync(TRequest request)
    {
        ValidateRequest(request);
        TEntity entity = _mapper.Map<TEntity>(request);
        bool hasReferences = await _repository.HasReferencesAsync(entity);
        if (hasReferences)
        {
            throw new InvalidOperationException("The entity cannot be deleted because it is referenced by other entities.");
        }
        entity.IsDeleted = true;
        return await _repository.DeleteAsync(entity);
    }

    public virtual async Task<List<TEntity>> ReadAsync()
    {
        return await _repository.ReadAsync();
    }

    public virtual TEntity? GetById(int id)
    {
        TEntity? entities =  _repository.GetById(id);
        return entities;
    }

    private void ValidateRequest(TRequest request)
    {
        var validationResult = _validator.Validate(request);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.ToString());
        }
    }
}
