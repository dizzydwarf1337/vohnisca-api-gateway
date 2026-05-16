namespace Application.Interfaces.RpcClients;

public interface IUserRpcClient
{
    Task<RpcResult<DefaultRpcResponse>> UpdateUserData(string userName, string bio, string token);
    Task<RpcResult<GetMeResult>> GetMe(string token);
    Task<RpcResult<DefaultRpcResponse>> SendFriendRequest(string userName, string token);
    Task<RpcResult<DefaultRpcResponse>> AcceptFriendRequest(Guid id, string token);
    Task<RpcResult<DefaultRpcResponse>> RejectFriendRequest(Guid id, string token);
    Task<RpcResult<GetFriendRequestsResult>> GetFriendRequests(string token);
}

public record GetMeResult(UserData Data, bool IsSuccess = true, string? Error = null, int StatusCode = 200)
    : DefaultRpcResponse(IsSuccess, Error, StatusCode);

public record UserData(
    string UserName,
    string Email,
    string Bio,
    DateTime CreatedAt,
    bool HasUnreadNotifications,
    bool HasUnreadMessages,
    int FriendsOnline);

public record GetFriendRequestsResult(
    FriendRequest[] FriendRequests,
    bool IsSuccess = true,
    string? Error = null,
    int StatusCode = 200)
    : DefaultRpcResponse(IsSuccess, Error, StatusCode);

public record FriendRequest(Guid Id, string UserName, string Status, DateTime SentAt);