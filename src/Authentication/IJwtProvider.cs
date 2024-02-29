namespace ClimaTempoWebAPI.Authentication;
public interface IJwtProvider
{
    string Generate(Guid customerId, string email);
}
