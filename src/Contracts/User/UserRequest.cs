namespace ClimaTempoWebAPI.Contracts.User
{
    public sealed record UserRequest(
     string FullName,
     string Email,
     string Password);
}
