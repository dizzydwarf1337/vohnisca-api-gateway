using Application.Core.ApiResponse;
using Application.Core.Responses;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Catalog.ListRaces;

public class ListRacesQueryHandler : IRequestHandler<ListRacesQuery, ApiResponse<PaginationResponse<RaceListRow>>>
{
    private readonly ICharacterRpcClient _client;
    public ListRacesQueryHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<PaginationResponse<RaceListRow>>> Handle(ListRacesQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.ListRaces(request.Page, request.PageSize, request.Token!);
        return result.ToApiResponse(x => x, "Error listing races");
    }
}
