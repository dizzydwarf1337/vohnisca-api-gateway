using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Catalog.GetRaceById;

public class GetRaceByIdQueryHandler : IRequestHandler<GetRaceByIdQuery, ApiResponse<RaceDetail>>
{
    private readonly ICharacterRpcClient _client;
    public GetRaceByIdQueryHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<RaceDetail>> Handle(GetRaceByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.GetRaceById(request.Id, request.Token!);
        return result.ToApiResponse(x => x, "Error getting race");
    }
}
