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

public record GetMeResult(bool IsSuccess, UserData Data,  string? Error);
public record UserData(string UserName, string Email, string Bio, DateTime CreatedAt, int UnreadNotificationsCount, int UnreadMessagesCount, int FriendsOnline);

public record GetFriendRequestsResult(FriendRequest[] FriendRequests) : DefaultRpcResponse;
public record FriendRequest(Guid Id, string UserName, string Status, DateTime SentAt);