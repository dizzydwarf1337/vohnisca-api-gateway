using Application.Core.ApiResponse;
using Application.Core.Mediatr.Requests.UserRequest;
using Application.Core.Responses;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Catalog.ListRaces;

public class ListRacesQuery : UserRequest<PaginationResponse<RaceListRow>>
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 100;
}

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
