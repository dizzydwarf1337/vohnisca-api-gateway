using Application.Core.ApiResponse;
using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Character.AddFeatureToCharacter;

public class AddFeatureToCharacterCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public Guid FeatureId { get; set; }
}

public class AddFeatureToCharacterCommandHandler : IRequestHandler<AddFeatureToCharacterCommand, ApiResponse<bool>>
{
    private readonly ICharacterRpcClient _client;
    public AddFeatureToCharacterCommandHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(AddFeatureToCharacterCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.AddFeatureToCharacter(request, request.Token!);
        return result.ToApiResponse(x => x, "Error adding feature");
    }
}
