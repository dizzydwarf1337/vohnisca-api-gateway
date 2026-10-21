using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Character.GetLearnableSpells;

public class GetLearnableSpellsQueryHandler : IRequestHandler<GetLearnableSpellsQuery, ApiResponse<List<LearnableSpellClassRow>>>
{
    private readonly ICharacterRpcClient _client;
    public GetLearnableSpellsQueryHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<List<LearnableSpellClassRow>>> Handle(GetLearnableSpellsQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.GetLearnableSpells(request.CharacterId, request.Token!);
        return result.ToApiResponse(x => x, "Error getting learnable spells");
    }
}
