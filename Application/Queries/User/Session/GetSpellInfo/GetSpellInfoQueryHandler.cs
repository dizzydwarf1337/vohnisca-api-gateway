using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Session.GetSpellInfo;

public class GetSpellInfoQueryHandler : IRequestHandler<GetSpellInfoQuery, ApiResponse<SpellInfoData>>
{
    private readonly ISessionRpcClient _client;
    public GetSpellInfoQueryHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SpellInfoData>> Handle(GetSpellInfoQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.GetSpellInfo(request, request.Token!);
        return result.ToApiResponse(x => x, "Error getting the spell");
    }
}
