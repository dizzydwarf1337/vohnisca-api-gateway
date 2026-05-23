using Application.Core.Mediatr.Requests.UserRequest;
using Application.Core.Requests;
using Application.Core.Responses;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.User.Friends.GetFriends;

public class GetFriendsQuery : UserRequest<PaginationResponse<Friend>>
{
    public PaginationSpecification Pagination { get; set; }
}