namespace Application.Interfaces.GrpcClients;

public interface IAuthGrpcClient
{
    Task<LoginResult> LoginAsync(string email, string password);
    Task<SignUpResult> SignUpAsync(string email, string password, string password_confimation, string name);
}

public record LoginResult(string access_token, string token_type, string expires_in);
public record SignUpResult(string token);