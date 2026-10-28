using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Catalog.GetFeatureById;

public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, ApiResponse<FeatureDetail>>
{
    private readonly IWorkshopRpcClient _client;
    public GetFeatureByIdQueryHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<FeatureDetail>> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.GetFeatureById(request.Id, request.Token!);
        return result.ToApiResponse(x => x, "Error getting feature");
    }
}
