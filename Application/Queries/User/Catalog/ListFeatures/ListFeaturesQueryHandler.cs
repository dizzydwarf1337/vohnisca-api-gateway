using Application.Core.ApiResponse;
using Application.Core.Responses;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Catalog.ListFeatures;

public class ListFeaturesQueryHandler : IRequestHandler<ListFeaturesQuery, ApiResponse<PaginationResponse<FeatureListRow>>>
{
    private readonly ICharacterRpcClient _client;
    public ListFeaturesQueryHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<PaginationResponse<FeatureListRow>>> Handle(ListFeaturesQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.ListFeatures(request.Page, request.PageSize, request.OnlySelectableAsFeat, request.Token!);
        return result.ToApiResponse(x => x, "Error listing features");
    }
}
