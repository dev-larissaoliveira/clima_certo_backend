using ClimaTempoWebAPI.Helper;

namespace ClimaTempoWebAPI.Contracts.Login;

public sealed record LoginRequest 
{
    public Guid UserId { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }

    public bool ValidPassword(string password)
    {
        return Password == password.HashGenerate();
    }
}
    ///(Guid UserId, string Email, string Password);