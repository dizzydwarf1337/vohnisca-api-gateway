using Application.Interfaces.RpcClients;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.RpcClients;

public class AuthRpcClient : LaravelRpcClient, IAuthRpcClient
{
    public AuthRpcClient(IConfiguration configuration)
        : base(configuration["RpcServices:AuthService"] ?? throw new Exception("AuthService URI not set")) { }

    public Task<RpcResult<LoginResult>> LoginAsync(string email, string password)
    {
        return SendRpcRequest<LoginResult>(
            "Login",
            new Dictionary<string, object>
            {
                { "email", email },
                { "password", password }
            },
            token: null,
            route: null,
            getErrorMessage: r => string.IsNullOrWhiteSpace(r.Message) ? null : r.Message
        );
    }

    public Task<RpcResult<SignUpResult>> SignUpAsync(string email, string password, string passwordConfirmation, string name)
    {
        return SendRpcRequest<SignUpResult>(
            "SignUp",
            new Dictionary<string, object>
            {
                { "email", email },
                { "password", password },
                { "passwordConfirmation", passwordConfirmation },
                { "name", name }
            },
            token: null,
            route: null,
            getErrorMessage: r => string.IsNullOrWhiteSpace(r.Message) ? null : r.Message
        );
    }

    public Task<RpcResult<ConfirmEmailResult>> ConfirmEmailAsync(string userMail, string token)
    {
        return SendRpcRequest<ConfirmEmailResult>(
            "ConfirmMail",
            new Dictionary<string, object>
            {
                { "userMail", userMail },
                { "token", token }
            },
            token: null,
            route: null,
            getErrorMessage: r => string.IsNullOrWhiteSpace(r.Message) ? null : r.Message
        );
    }

    public Task<RpcResult<RefreshToken>> RefreshToken(string refreshToken)
    {
        return SendRpcRequest<RefreshToken>(
            "Refresh",
            new Dictionary<string, object>
            {
                { "refreshToken", refreshToken }
            },
            token: null,
            route: null,
            getErrorMessage: r => string.IsNullOrWhiteSpace(r.Message) ? null : r.Message
        );
    }
}