using ClimaTempoWebAPI.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace ClimaTempoWebAPI.Data.Repositories
{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<User>> GetUsersAsync(CancellationToken cancellationToken = default) =>
            await _context.Set<User>().ToListAsync(cancellationToken);

        public void AddUser(User user) 
        {
            user.SetHashPassword();

            _context.Set<User>().Add(user);
            _context.SaveChangesAsync();
        }
    }
}
