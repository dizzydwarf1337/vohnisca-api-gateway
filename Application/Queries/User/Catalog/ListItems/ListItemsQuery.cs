using Application.Core.Mediatr.Requests.UserRequest;
using Application.Core.Responses;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Catalog.ListItems;

public class ListItemsQuery : UserRequest<PaginationResponse<ItemListRow>>
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 100;
    // "all" by default (what the viewer can see); also "mine", "system", "global" — the workshop decides.
    public string? Scope { get; set; }
    public string? Search { get; set; }
}
