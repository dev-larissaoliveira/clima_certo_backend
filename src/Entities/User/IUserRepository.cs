using ClimaTempoWebAPI.Entities.Customers;

namespace ClimaTempoWebAPI.Entities.User
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync(CancellationToken cancellationToken = default);
        void AddUser(User user);
    }
}
