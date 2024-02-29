using ClimaTempoWebAPI.Helper;
using System.ComponentModel.DataAnnotations;

namespace ClimaTempoWebAPI.Models
{
    public class UserModel
    {
        public long Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public int Role { get; set; }

        public bool Active { get; set; }
    }
}
