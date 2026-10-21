using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Character.GetCreationOptions;

public class GetCreationOptionsQueryHandler : IRequestHandler<GetCreationOptionsQuery, ApiResponse<List<CreationChoiceRow>>>
{
    private readonly ICharacterRpcClient _client;
    public GetCreationOptionsQueryHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<List<CreationChoiceRow>>> Handle(GetCreationOptionsQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.GetCreationOptions(request, request.Token!);
        return result.ToApiResponse(x => x, "Error getting creation options");
    }
}
