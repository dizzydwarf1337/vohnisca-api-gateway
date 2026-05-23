using Application.Core.Requests;
using Application.Interfaces.RpcClients;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.RpcClients;

public class UserRpcClient : DotnetRpcClient, IUserRpcClient
{
    public UserRpcClient(IConfiguration configuration)
        : base(configuration["RpcServices:UserService"] ?? throw new Exception("UserService URI not set"))
    {
    }

    public Task<RpcResult<DefaultRpcResponse>> UpdateUserData(string userName, string bio, string token)
        => SendRpcRequest<DefaultRpcResponse>("User.UpdateUserData",
            new Dictionary<string, object> { { "UserName", userName }, { "Bio", bio } }, token: token);

    public Task<RpcResult<GetMeResult>> GetMe(string token)
        => SendRpcRequest<GetMeResult>("GetMe", token: token);

    public Task<RpcResult<DefaultRpcResponse>> SendFriendRequest(string userName, string token)
        => SendRpcRequest<DefaultRpcResponse>("SendFriendRequest",
            new Dictionary<string, object> { { "UserName", userName } }, token: token);

    public Task<RpcResult<DefaultRpcResponse>> AcceptFriendRequest(Guid id, string token)
        => SendRpcRequest<DefaultRpcResponse>("AcceptFriendRequest", new Dictionary<string, object> { { "Id", id } },
            token: token);

    public Task<RpcResult<DefaultRpcResponse>> RejectFriendRequest(Guid id, string token)
        => SendRpcRequest<DefaultRpcResponse>("RejectFriendRequest", new Dictionary<string, object> { { "Id", id } },
            token: token);

    public Task<RpcResult<DefaultRpcResponse>> CancelFriendRequest(Guid id, string token)
        => SendRpcRequest<DefaultRpcResponse>("CancelFriendRequest", new Dictionary<string, object> { { "Id", id } },
            token: token);

    public Task<RpcResult<DefaultRpcResponse>> DeleteFriendRequest(Guid id, string token)
        => SendRpcRequest<DefaultRpcResponse>("DeleteFriendRequest", new Dictionary<string, object> { { "Id", id } },
            token: token);

    public Task<RpcResult<DefaultRpcResponse>> DeleteFriend(Guid id, string token)
        => SendRpcRequest<DefaultRpcResponse>("DeleteFriend", new Dictionary<string, object> { { "Id", id } },
            token: token);

    public Task<RpcResult<GetFriendRequestsResult>> GetFriendRequests(PaginationSpecification pagination, string token)
        => SendRpcRequest<GetFriendRequestsResult>("ReceivedFriendRequests",
            new Dictionary<string, object> { { "Pagination", pagination } }, token: token);

    public Task<RpcResult<GetFriendRequestsResult>> GetSentFriendRequests(PaginationSpecification pagination,
        string token)
        => SendRpcRequest<GetFriendRequestsResult>("SentFriendRequests",
            new Dictionary<string, object> { { "Pagination", pagination } }, token: token);

    public Task<RpcResult<GetFriendsResult>> GetFriends(PaginationSpecification pagination, string token)
        => SendRpcRequest<GetFriendsResult>("GetFriends",
            new Dictionary<string, object> { { "Pagination", pagination } }, token: token);
}