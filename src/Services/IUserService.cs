using ClimaTempoWebAPI.Contracts;
using ClimaTempoWebAPI.Contracts.User;
using ClimaTempoWebAPI.Entities.User;
using Microsoft.AspNetCore.Mvc;

namespace ClimaTempoWebAPI.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync(CancellationToken cancellationToken = default);
        Task<ServiceResponse<User>> GetUserById(int id);
        void AddUser(UserRequest request);
        Task<ServiceResponse<User>> UpdateUser(User user);
        Task<ServiceResponse<List<User>>> DeleteUser(int id);
        Task<ServiceResponse<List<User>>> DisableUser(int id);
    }
}
