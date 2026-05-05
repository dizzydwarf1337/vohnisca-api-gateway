using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.User.FriendRequests.GetFriendRequests;

public class GetFriendRequestsQuery : UserRequest<FriendRequest[]>;