using AutoMapper;
using Crm.Admin.Service.Models;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.UserRequests;
using FluentValidation;

namespace CRM.Tenant.Service.Services
{
    public class UserService : BaseService<CreateUserRequest, UserModel>
    {
        public UserService(IMapper mapper, BaseRepository<UserModel> repository, IValidator<CreateUserRequest> validator) : base(mapper, repository, validator)
        {
        }
    }
}
