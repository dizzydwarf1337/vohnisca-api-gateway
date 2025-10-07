namespace Application.Interfaces.RpcClients;

public interface IAuthRpcClient
{
    Task<RpcResult<LoginResult>> LoginAsync(string email, string password);
    Task<RpcResult<SignUpResult>> SignUpAsync(string email, string password, string passwordConfirmation, string name);
}

public record LoginResult(string? AccessToken = null, string? TokenType = null, int? ExpiresIn = null, string? Message = null);
public record SignUpResult(string? Token, string? Message);