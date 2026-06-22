using Application.Core.ApiResponse;
using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Character.GetSharedCharactersList;

public class GetSharedCharactersListQuery : UserRequest<List<SharedCharacterRow>>
{
}

public class GetSharedCharactersListQueryHandler : IRequestHandler<GetSharedCharactersListQuery, ApiResponse<List<SharedCharacterRow>>>
{
    private readonly ICharacterRpcClient _client;
    public GetSharedCharactersListQueryHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<List<SharedCharacterRow>>> Handle(GetSharedCharactersListQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.GetSharedCharactersList(request.Token!);
        return result.ToApiResponse(x => x, "Error getting shared characters");
    }
}
