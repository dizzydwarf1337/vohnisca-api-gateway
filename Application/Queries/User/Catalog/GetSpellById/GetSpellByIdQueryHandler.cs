using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Catalog.GetSpellById;

public class GetSpellByIdQueryHandler : IRequestHandler<GetSpellByIdQuery, ApiResponse<SpellDetail>>
{
    private readonly IWorkshopRpcClient _client;
    public GetSpellByIdQueryHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<SpellDetail>> Handle(GetSpellByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.GetSpellById(request.Id, request.Token!);
        return result.ToApiResponse(x => x, "Error getting spell");
    }
}
