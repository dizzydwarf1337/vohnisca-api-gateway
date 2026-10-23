using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Catalog.GetSpellInfo;

public class GetSpellInfoQueryHandler : IRequestHandler<GetSpellInfoQuery, ApiResponse<CatalogSpellInfo>>
{
    private readonly ICharacterRpcClient _client;
    public GetSpellInfoQueryHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<CatalogSpellInfo>> Handle(GetSpellInfoQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.GetSpellInfo(request.SpellId, request.CharacterId, request.Token!);
        return result.ToApiResponse(x => x, "Error getting spell details");
    }
}
