namespace Application.Interfaces.RpcClients;

public interface IAuthRpcClient
{
    Task<LoginResult> LoginAsync(string email, string password);
    Task<SignUpResult> SignUpAsync(string email, string password, string passwordConfirmation, string name);
}

public record LoginResult(bool IsSuccess, string? AccessToken, string? TokenType, string? ExpiresIn, string? Error = null);
public record SignUpResult(bool IsSuccess, string? Token, string? Error = null);