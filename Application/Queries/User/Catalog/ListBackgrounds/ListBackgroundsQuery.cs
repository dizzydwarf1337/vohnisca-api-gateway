using Application.Core.Mediatr.Requests.UserRequest;
using Application.Core.Responses;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Catalog.ListBackgrounds;

public class ListBackgroundsQuery : UserRequest<PaginationResponse<BackgroundListRow>>
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 100;
}
