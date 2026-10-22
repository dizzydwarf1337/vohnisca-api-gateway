using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Character.GetLevelUpOptions;

public class GetLevelUpOptionsQueryHandler : IRequestHandler<GetLevelUpOptionsQuery, ApiResponse<List<CreationChoiceRow>>>
{
    private readonly ICharacterRpcClient _client;
    public GetLevelUpOptionsQueryHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<List<CreationChoiceRow>>> Handle(GetLevelUpOptionsQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.GetLevelUpOptions(request, request.Token!);
        return result.ToApiResponse(x => x, "Error getting level up options");
    }
}
