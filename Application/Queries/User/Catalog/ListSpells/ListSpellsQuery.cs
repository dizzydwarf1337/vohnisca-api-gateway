using Application.Core.Mediatr.Requests.UserRequest;
using Application.Core.Responses;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Catalog.ListSpells;

public class ListSpellsQuery : UserRequest<PaginationResponse<SpellListRow>>
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 100;
    public int? Level { get; set; }
}
