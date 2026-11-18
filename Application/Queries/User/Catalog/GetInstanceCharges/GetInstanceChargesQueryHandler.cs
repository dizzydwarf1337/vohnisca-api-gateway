using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Catalog.GetInstanceCharges;

public class GetInstanceChargesQueryHandler : IRequestHandler<GetInstanceChargesQuery, ApiResponse<InstanceChargesData>>
{
    private readonly ICharacterRpcClient _client;
    public GetInstanceChargesQueryHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<InstanceChargesData>> Handle(GetInstanceChargesQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.GetInstanceCharges(request.InstanceId, request.ItemId, request.Token!);
        return result.ToApiResponse(x => x, "Error getting the item's charges");
    }
}
