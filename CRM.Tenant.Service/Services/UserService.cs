using AutoMapper;
using Crm.Admin.Service.Models;
using Crm.Tenant.Data;
using Crm.Tenant.Data.Repositories;
using CRM.Tenant.Service.Models.Requests.UserRequests;
using FluentValidation;

namespace CRM.Tenant.Service.Services
{
    public class UserService : BaseService<CreateUserRequest, UserModel>
    {
        private BaseRepository<UserModel> _repository;
        public UserService(IMapper mapper, BaseRepository<UserModel> repository, IValidator<CreateUserRequest> validator, IUnitOfWork unitOfWork) : base(mapper, repository, validator, unitOfWork)
        {
            _repository = repository;
        }

        public async Task<UserModel?> Create(CreateUserRequest user)
        {
            bool isExist = await _repository.ExistsAsync(u => u.Username == user.Username);
            if (isExist == false) 
            {
                return await base.CreateAsync(user);
            }
            return null;
        }

        public async Task UpdateLastLoginTime(string userName)
        {
            List<UserModel> users = await _repository.ReadAsync();

            UserModel? user = users.FirstOrDefault(u => u.Username == userName);

            if (user != null)
            {
                user.LastLogin = DateTime.Now;
                _repository.UpdateAsync(user);
            }
        }

        public async Task<bool> DeleteUser(string username)
        {
            List<UserModel> users = await _repository.ReadAsync();

            UserModel? user = users.FirstOrDefault(u => u.Username == username);

            if (user != null)
            {
                user.IsDeleted = true;
                var res =  _repository.UpdateAsync(user);
                if (res != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
