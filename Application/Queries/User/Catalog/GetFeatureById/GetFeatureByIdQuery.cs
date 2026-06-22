using Application.Core.ApiResponse;
using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Catalog.GetFeatureById;

public class GetFeatureByIdQuery : UserRequest<FeatureDetail>
{
    public Guid Id { get; set; }
}

public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, ApiResponse<FeatureDetail>>
{
    private readonly ICharacterRpcClient _client;
    public GetFeatureByIdQueryHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<FeatureDetail>> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.GetFeatureById(request.Id, request.Token!);
        return result.ToApiResponse(x => x, "Error getting feature");
    }
}
