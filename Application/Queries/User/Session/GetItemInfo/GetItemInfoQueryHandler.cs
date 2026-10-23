using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Session.GetItemInfo;

public class GetItemInfoQueryHandler : IRequestHandler<GetItemInfoQuery, ApiResponse<ItemInfoData>>
{
    private readonly ISessionRpcClient _client;
    public GetItemInfoQueryHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<ItemInfoData>> Handle(GetItemInfoQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.GetItemInfo(request, request.Token!);
        return result.ToApiResponse(x => x, "Error getting the item");
    }
}
