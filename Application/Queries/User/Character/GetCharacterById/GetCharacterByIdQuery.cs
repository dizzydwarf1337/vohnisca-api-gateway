using Application.Core.ApiResponse;
using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Character.GetCharacterById;

public class GetCharacterByIdQuery : UserRequest<CharacterSheetData>
{
    public Guid Id { get; set; }
}

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
