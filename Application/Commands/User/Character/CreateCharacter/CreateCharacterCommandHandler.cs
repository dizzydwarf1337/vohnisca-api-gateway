using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Character.CreateCharacter;

public class CreateCharacterCommandHandler : IRequestHandler<CreateCharacterCommand, ApiResponse<CreateCharacterData>>
{
    private readonly ICharacterRpcClient _client;
    public CreateCharacterCommandHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<CreateCharacterData>> Handle(CreateCharacterCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.CreateCharacter(request, request.Token!);
        return result.ToApiResponse(x => x, "Error creating character");
    }
}
