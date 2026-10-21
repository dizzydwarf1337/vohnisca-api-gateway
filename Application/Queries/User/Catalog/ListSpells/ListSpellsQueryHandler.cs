using Application.Core.ApiResponse;
using Application.Core.Responses;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Catalog.ListSpells;

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
