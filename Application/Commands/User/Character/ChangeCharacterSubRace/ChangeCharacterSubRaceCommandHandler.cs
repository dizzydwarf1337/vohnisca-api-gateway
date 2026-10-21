using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Character.ChangeCharacterSubRace;

public class ChangeCharacterSubRaceCommandHandler : IRequestHandler<ChangeCharacterSubRaceCommand, ApiResponse<bool>>
{
    private readonly ICharacterRpcClient _client;
    public ChangeCharacterSubRaceCommandHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(ChangeCharacterSubRaceCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.ChangeCharacterSubRace(request, request.Token!);
        return result.ToApiResponse(x => x, "Error changing subrace");
    }
}
