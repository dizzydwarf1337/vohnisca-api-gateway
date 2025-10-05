
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

    public async Task<LoginResult> LoginAsync(string email, string password)
    {
        var parameters = new RpcParameters(new Dictionary<string, object>
        {
            { "email", email },
            { "password", password }
        });
        var response = await _rpcClient.SendAsync<LoginResult>(
                new RpcRequest(
                    "Login",
                    parameters
                )
        );
        return new LoginResult(response.Result.access_token, response.Result.token_type, response.Result.expires_in);
    }

    public async Task<SignUpResult> SignUpAsync(string email, string password, string password_confirmation, string name)
    {
        var parameters = new RpcParameters(new Dictionary<string, object>
        {
            { "email", email },
            { "password", password },
            { "password_confirmation", password_confirmation },
            { "name", name }
        });
        var response = await _rpcClient.SendAsync<SignUpResult>(
            new RpcRequest(
            "SignUp",
            parameters
            )
        );
        return new SignUpResult(response.Result.token);
    }
    
}