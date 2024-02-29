using ClimaTempoWebAPI.Contracts.Login;

namespace ClimaTempoWebAPI.Services;
public interface ILoginService
{
    SignInResponse SignIn(LoginRequest request);
}
