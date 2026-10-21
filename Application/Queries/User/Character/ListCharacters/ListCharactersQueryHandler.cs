using Application.Core.ApiResponse;
using Application.Core.Responses;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Character.ListCharacters;

public class ListCharactersQueryHandler : IRequestHandler<ListCharactersQuery, ApiResponse<PaginationResponse<CharacterListRow>>>
{
    private readonly ICharacterRpcClient _client;
    public ListCharactersQueryHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<PaginationResponse<CharacterListRow>>> Handle(ListCharactersQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.ListCharacters(request.Page, request.PageSize, request.Token!);
        return result.ToApiResponse(x => x, "Error listing characters");
    }
}
