using Application.Core.Requests;
using Application.Core.Responses;

namespace Application.Interfaces.RpcClients;

public interface IUserRpcClient
{
    Task<RpcResult<DefaultRpcResponse>> UpdateUserData(string userName, string bio, string token);
    Task<RpcResult<GetMeResult>> GetMe(string token);
    Task<RpcResult<DefaultRpcResponse>> SendFriendRequest(string userName, string token);
    Task<RpcResult<DefaultRpcResponse>> AcceptFriendRequest(Guid id, string token);
    Task<RpcResult<DefaultRpcResponse>> RejectFriendRequest(Guid id, string token);
    Task<RpcResult<DefaultRpcResponse>> CancelFriendRequest(Guid id, string token);
    Task<RpcResult<DefaultRpcResponse>> DeleteFriendRequest(Guid id, string token);
    Task<RpcResult<DefaultRpcResponse>> DeleteFriend(Guid id, string token);
    Task<RpcResult<GetFriendRequestsResult>> GetFriendRequests(PaginationSpecification pagination, string token);
    Task<RpcResult<GetFriendRequestsResult>> GetSentFriendRequests(PaginationSpecification pagination, string token);
    Task<RpcResult<GetFriendsResult>> GetFriends(PaginationSpecification pagination, string token);
}

public record GetMeResult(UserData Data, bool IsSuccess = true, string? Error = null, int StatusCode = 200)
    : DefaultRpcResponse(IsSuccess, Error, StatusCode);

public record GetFriendRequestsResult(
    PaginationResponse<FriendRequest> Data,
    bool IsSuccess = true,
    string? Error = null,
    int StatusCode = 200)
    : DefaultRpcResponse(IsSuccess, Error, StatusCode);

public record GetFriendsResult(
    PaginationResponse<Friend> Data,
    bool IsSuccess = true,
    string? Error = null,
    int StatusCode = 200) : DefaultRpcResponse(IsSuccess, Error, StatusCode);

public record UserData(
    string UserName,
    string Email,
    string Bio,
    DateTime CreatedAt,
    bool HasUnreadNotifications,
    bool HasUnreadMessages,
    int FriendsOnline);

public record FriendRequest(Guid Id, string UserName, string Status, DateTime SentAt, DateTime? StatusChangedAt);

public record Friend(Guid Id, string UserName, DateTime? LastSeen);