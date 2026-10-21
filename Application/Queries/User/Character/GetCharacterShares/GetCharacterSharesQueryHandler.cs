using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Character.GetCharacterShares;

public class GetCharacterSharesQueryHandler : IRequestHandler<GetCharacterSharesQuery, ApiResponse<List<CharacterShareRow>>>
{
    private readonly ICharacterRpcClient _client;
    public GetCharacterSharesQueryHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<List<CharacterShareRow>>> Handle(GetCharacterSharesQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.GetCharacterShares(request.CharacterId, request.Token!);
        return result.ToApiResponse(x => x, "Error getting character shares");
    }
}
