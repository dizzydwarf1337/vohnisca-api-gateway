using Application.Core.ApiResponse;
using Application.Core.Mediatr.Requests.UserRequest;
using Application.Core.Responses;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Catalog.ListSpells;

public class ListSpellsQuery : UserRequest<PaginationResponse<SpellListRow>>
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 100;
    public int? Level { get; set; }
}

public class ListSpellsQueryHandler : IRequestHandler<ListSpellsQuery, ApiResponse<PaginationResponse<SpellListRow>>>
{
    private readonly ICharacterRpcClient _client;
    public ListSpellsQueryHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<PaginationResponse<SpellListRow>>> Handle(ListSpellsQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.ListSpells(request.Page, request.PageSize, request.Level, request.Token!);
        return result.ToApiResponse(x => x, "Error listing spells");
    }
}
