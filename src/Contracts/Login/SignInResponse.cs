using ClimaTempoWebAPI.Models;

namespace ClimaTempoWebAPI.Contracts.Login
{
    public sealed class SignInResponse
    {
        public string Token { get; set; } = string.Empty;
        public UserModel? User{ get; set; }
    }
}
