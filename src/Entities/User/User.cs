using ClimaTempoWebAPI.Helper;
using System.ComponentModel.DataAnnotations;

namespace ClimaTempoWebAPI.Entities.User
{
    public sealed class User
    {
        [Key]
        public long Id { get; set; }

        public Guid User_uuid { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public int Role { get; set; }

        public bool Active { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now.ToLocalTime();

        public DateTime UpdateAt { get; set; } = DateTime.Now.ToLocalTime();

        public bool ValidPassword(string password)
        {
            return Password == password.HashGenerate();
        }

        public void SetHashPassword()
        {
            if (Password != null)
                Password = Password.HashGenerate();
        }
    }
}
