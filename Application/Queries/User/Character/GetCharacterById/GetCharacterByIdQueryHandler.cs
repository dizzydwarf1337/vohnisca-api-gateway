using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Character.GetCharacterById;

public class GetCharacterByIdQueryHandler : IRequestHandler<GetCharacterByIdQuery, ApiResponse<CharacterSheetData>>
{
    private readonly ICharacterRpcClient _client;
    public GetCharacterByIdQueryHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<CharacterSheetData>> Handle(GetCharacterByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.GetCharacterById(request.Id, request.Token!);
        return result.ToApiResponse(x => x, "Error getting character");
    }
}
