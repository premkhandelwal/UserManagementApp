using AutoMapper;
using Crm.Admin.Service.Models;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.UserRequests;
using FluentValidation;

namespace CRM.Tenant.Service.Services
{
    public class UserService : BaseService<CreateUserRequest, UserModel>
    {
        private BaseRepository<UserModel> _repository;
        public UserService(IMapper mapper, BaseRepository<UserModel> repository, IValidator<CreateUserRequest> validator) : base(mapper, repository, validator)
        {
            _repository = repository;
        }

        public async Task UpdateLastLoginTime(string emailId)
        {
            List<UserModel> users = await _repository.ReadAsync();

            UserModel? user = users.FirstOrDefault(u => u.EmailId == emailId);

            if (user != null)
            {
                user.LastLogin = DateTime.Now;
                await _repository.UpdateAsync(user);
            }
        }
    }
}
