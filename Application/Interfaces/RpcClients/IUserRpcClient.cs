namespace Application.Interfaces.RpcClients;

public interface IUserRpcClient
{
    Task<RpcResult<UpdateUserDataResult>> UpdateUserData(string userName, string bio, string token);
}

public record UpdateUserDataResult(bool IsSuccess, string? Error);