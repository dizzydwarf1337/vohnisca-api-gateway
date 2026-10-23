using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Catalog.GetItemInfo;

public class GetItemInfoQueryHandler : IRequestHandler<GetItemInfoQuery, ApiResponse<CatalogItemInfo>>
{
    private readonly ICharacterRpcClient _client;
    public GetItemInfoQueryHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<CatalogItemInfo>> Handle(GetItemInfoQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.GetItemInfo(request.ItemId, request.Token!);
        return result.ToApiResponse(x => x, "Error getting item details");
    }
}
