using Application.Interfaces.RpcClients;
using EdjCase.JsonRpc.Client;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.RpcClients;

public class AuthRpcClient : BaseRpcClient, IAuthRpcClient
{
    public AuthRpcClient(IConfiguration configuration) 
        : base(configuration["RpcServices:AuthService"] ?? throw new Exception("AuthService URI not set")) { }

    public async Task<RpcResult<LoginResult>> LoginAsync(string email, string password)
    {
        var rpcClient = CreateRpcClient();
        
        var parameters = new RpcParameters(new Dictionary<string, object>
        {
            { "email", email },
            { "password", password }
        });
        
        var request = new RpcRequest(
            id: Guid.NewGuid().ToString(),
            method: "Login",
            parameters: parameters
        );
        
        var response = await rpcClient.SendAsync<LoginResult>(request);
        
        if (response.HasError)
            return RpcResult<LoginResult>.Failure(response.Error?.Message ?? "Unknown RPC error");
        
        return string.IsNullOrWhiteSpace(response.Result.Message)
            ? RpcResult<LoginResult>.Success(response.Result)
            : RpcResult<LoginResult>.Failure(response.Result.Message);
    }

    public async Task<RpcResult<SignUpResult>> SignUpAsync(string email, string password, string passwordConfirmation, string name)
    {
        var rpcClient = CreateRpcClient();
        
        var parameters = new RpcParameters(new Dictionary<string, object>
        {
            { "email", email },
            { "password", password },
            { "passwordConfirmation", passwordConfirmation },
            { "name", name }
        });
        
        var request = new RpcRequest(
            id: Guid.NewGuid().ToString(),
            method: "SignUp",
            parameters: parameters
        );
        
        var response = await rpcClient.SendAsync<SignUpResult>(request);
        
        if (response.HasError)
            return RpcResult<SignUpResult>.Failure(response.Error?.Message ?? "Unknown RPC error");
        
        return string.IsNullOrEmpty(response.Result.Message)
            ? RpcResult<SignUpResult>.Success(response.Result)
            : RpcResult<SignUpResult>.Failure(response.Result.Message);
    }

    public async Task<RpcResult<ConfirmEmailResult>> ConfirmEmailAsync(string userMail, string token)
    {
        var rpcClient = CreateRpcClient();
        
        var parameters = new RpcParameters(new Dictionary<string, object>
        {
            { "userMail", userMail },
            { "token", token }
        });

        var request = new RpcRequest(
            id: Guid.NewGuid().ToString(),
            method: "ConfirmMail",
            parameters: parameters
        );
        
        var response = await rpcClient.SendAsync<ConfirmEmailResult>(request);
        
        if (response.HasError)
            return RpcResult<ConfirmEmailResult>.Failure(response.Error?.Message ?? "Unknown RPC error");
        
        return string.IsNullOrEmpty(response.Result.Message)
            ? RpcResult<ConfirmEmailResult>.Success(response.Result)
            : RpcResult<ConfirmEmailResult>.Failure(response.Result.Message);
    }
}