using ClimaTempoWebAPI.Authentication;
using ClimaTempoWebAPI.Contracts.Login;
using ClimaTempoWebAPI.Entities.User;

namespace ClimaTempoWebAPI.Services;

internal sealed class LoginService(IJwtProvider jwtProvider, IUserRepository userRepository) : ILoginService
{
    private readonly IJwtProvider _jwtProvider = jwtProvider;
    private readonly IUserRepository _userRepository = userRepository;

    public SignInResponse SignIn(LoginRequest request)
    {
        var user = _userRepository.GetUsersAsync().Result.FirstOrDefault(u => u.Email == request.Email);

        if (user == null || !user.Active)
        {
            throw new Exception($"Nenhum usuário encontrado para o e-mail informado.");
        }

        if (!user.ValidPassword(request.Password))
        {
            throw new Exception($"Senha incorreta.");
        }

        var token = _jwtProvider.Generate(user.User_uuid, request.Email);

        return new SignInResponse()
        {
            Token = token,
            User = new Models.UserModel()
            {
                Active = user.Active,
                Email = user.Email,
                Username = user.Email,
                Role = user.Role,
                Id = user.Id,
                FullName = user.FullName
            }
        };
    }
}