namespace Application.Interfaces.RpcClients;

public interface IAuthRpcClient
{
    Task<RpcResult<LoginResult>> LoginAsync(string email, string password);
    Task<RpcResult<SignUpResult>> SignUpAsync(string email, string password, string passwordConfirmation, string name);
    Task<RpcResult<ConfirmEmailResult>> ConfirmEmailAsync(string userMail, string token);
    Task<RpcResult<RefreshToken>> RefreshToken(string refreshToken);
}

public record LoginResult(string AccessToken, string RefreshToken, string TokenType, int ExpiresIn, string? Message);
public record SignUpResult(string? Message);
public record ConfirmEmailResult(string? Message);
public record RefreshToken(string AccessToken, string TokenType, int ExpiresIn, string Message);