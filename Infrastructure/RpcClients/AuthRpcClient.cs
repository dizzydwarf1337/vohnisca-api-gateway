using Application.Interfaces.RpcClients;
using EdjCase.JsonRpc.Client;

namespace Infrastructure.RpcClients;

public class AuthRpcClient : IAuthRpcClient
{
    private readonly RpcClient _rpcClient;

    public AuthRpcClient(RpcClient rpcClient)
    {
        _rpcClient = rpcClient;
    }

    public async Task<RpcResult<LoginResult>> LoginAsync(string email, string password)
    {
        var parameters = new RpcParameters(new Dictionary<string, object>
        {
            { "email", email },
            { "password", password }
        });
        var response = await _rpcClient.SendAsync<LoginResult>(
                new RpcRequest(
                    id: Guid.NewGuid().ToString(),
                    "Login",
                    parameters
                )
        );
        
        if(response.HasError)
            return RpcResult<LoginResult>.Failure(response.Error?.Message);

        if (!string.IsNullOrWhiteSpace(response.Result.Message))
            return RpcResult<LoginResult>.Failure(response.Result.Message);

        return RpcResult<LoginResult>.Success(response.Result);

    }

    public async Task<RpcResult<SignUpResult>> SignUpAsync(string email, string password, string passwordConfirmation, string name)
    {
        var parameters = new RpcParameters(new Dictionary<string, object>
        {
            { "email", email },
            { "password", password },
            { "passwordConfirmation", passwordConfirmation },
            { "name", name }
        });
        var response = await _rpcClient.SendAsync<SignUpResult>(
            new RpcRequest(
            "SignUp",
            parameters
            )
        );
        
        if(response.HasError)
            return RpcResult<SignUpResult>.Failure(response.Error?.Message);

        return !response.Result.IsSuccess
            ? RpcResult<SignUpResult>.Failure(string.IsNullOrEmpty(response.Result.Message) ? response.Result.Message : "Error while signing up.")
            : RpcResult<SignUpResult>.Success(response.Result);

    }
    
}