using Application.Core.Mediatr.Requests.UserRequest;
using Application.Core.Requests;
using Application.Core.Responses;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.User.FriendRequests.GetSentFriendRequests;

public class GetSentFriendRequestsQuery : UserRequest<PaginationResponse<FriendRequest>>
{
    public PaginationSpecification Pagination { get; set; }
}