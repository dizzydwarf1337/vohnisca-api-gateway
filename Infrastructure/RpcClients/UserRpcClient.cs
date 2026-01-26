using Application.Interfaces.RpcClients;
using EdjCase.JsonRpc.Client;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.RpcClients;

public class UserRpcClient : BaseRpcClient, IUserRpcClient
{
    public UserRpcClient(IConfiguration configuration) 
        : base(configuration["RpcServices:UserService"] ?? throw new Exception("UserService URI not set")) { }

    public async Task<RpcResult<UpdateUserDataResult>> UpdateUserData(string userName, string bio, string token)
    {
        var rpcClient = CreateRpcClient("user/update-user-data", token);
        
        var parameters = new RpcParameters(new Dictionary<string, object>
        {
            { "UserName", userName },
            { "Bio", bio }
        });

        var request = new RpcRequest(
            id: Guid.NewGuid().ToString(),
            method: "UserUpdateUserData",
            parameters: parameters
        );
        
        var response = await rpcClient.SendAsync<UpdateUserDataResult>(request);
        
        if (response.HasError)
            return RpcResult<UpdateUserDataResult>.Failure(response.Error?.Message ?? "Unknown RPC error");
        
        if (!response.Result.IsSuccess)
            return RpcResult<UpdateUserDataResult>.Failure(response.Result.Error ?? "Operation failed");

        return RpcResult<UpdateUserDataResult>.Success(response.Result);
    }
}