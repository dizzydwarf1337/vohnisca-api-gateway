using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Catalog.GetBackgroundById;

public class GetBackgroundByIdQueryHandler : IRequestHandler<GetBackgroundByIdQuery, ApiResponse<BackgroundDetail>>
{
    private readonly ICharacterRpcClient _client;
    public GetBackgroundByIdQueryHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<BackgroundDetail>> Handle(GetBackgroundByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.GetBackgroundById(request.Id, request.Token!);
        return result.ToApiResponse(x => x, "Error getting background");
    }
}
