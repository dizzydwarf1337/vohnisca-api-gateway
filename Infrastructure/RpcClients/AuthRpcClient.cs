using Application.Interfaces.RpcClients;
using EdjCase.JsonRpc.Client;
using EdjCase.JsonRpc.Common;

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
                    id: new RpcId(Guid.NewGuid().ToString()),
                    "Login",
                    parameters
                )
        );
        
        if(response.HasError)
            return RpcResult<LoginResult>.Failure(response.Error?.Message);

        return string.IsNullOrWhiteSpace(response.Result.Message)
            ? RpcResult<LoginResult>.Success(response.Result)
            : RpcResult<LoginResult>.Failure(response.Result.Message);

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

        return string.IsNullOrEmpty(response.Result.Message)
            ? RpcResult<SignUpResult>.Success(response.Result)
            : RpcResult<SignUpResult>.Failure(response.Result.Message);

    }

    public async Task<RpcResult<ConfirmEmailResult>> ConfirmEmailAsync(string userMail, string token)
    {
        var parameters = new RpcParameters(new Dictionary<string, object>
        {
            { "userMail", userMail },
            { "token", token }
        });

        var response = await _rpcClient.SendAsync<ConfirmEmailResult>(
            new RpcRequest(
                "ConfirmMail",
                parameters)
            );
        
        if(response.HasError)
            return RpcResult<ConfirmEmailResult>.Failure(response.Error?.Message);
        
        return string.IsNullOrEmpty(response.Result.Message)
            ? RpcResult<ConfirmEmailResult>.Success(response.Result)
            : RpcResult<ConfirmEmailResult>.Failure(response.Result.Message);
    }
}