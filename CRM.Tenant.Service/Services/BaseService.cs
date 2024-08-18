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
        return await _repository.DeleteAsync(entity);
    }

    public virtual async Task<List<TEntity>> ReadAsync()
    {
        return await _repository.ReadAsync();
    }

    public virtual async Task<List<TEntity>> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
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
