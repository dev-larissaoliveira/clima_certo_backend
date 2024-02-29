using Azure.Core;
using ClimaTempoWebAPI.Contracts;
using ClimaTempoWebAPI.Contracts.User;
using ClimaTempoWebAPI.Entities.User;

namespace ClimaTempoWebAPI.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;

        public void AddUser(UserRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            var emailExist = _userRepository.GetUsersAsync().Result.Any(u => u.Email == request.Email);

            if (emailExist) throw new Exception($"E-mail já cadastrado.");
                       
            var user = new User
            {
                FullName = request.FullName,
                Email = request.Email,
                Active = true,
                Password = request.Password,
                Username = request.Email,
                Role = 1,
            };

            _userRepository.AddUser(user);
        }

        public Task<ServiceResponse<List<User>>> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<User>>> DisableUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<User>> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetUsersAsync(CancellationToken cancellationToken = default)
        {
            var users = await _userRepository.GetUsersAsync(cancellationToken);

            return users.Select(user => new User
            {
                FullName = user.FullName,
                Username = user.Username,
                Active =  user.Active,
                Role = user.Role,
                UpdateAt = user.UpdateAt,
                Id = user.Id,
                Password = user.Password,
                CreatedAt = user.CreatedAt
            });
        }

        public Task<ServiceResponse<User>> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
