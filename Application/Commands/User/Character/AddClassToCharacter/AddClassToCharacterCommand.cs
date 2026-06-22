using Application.Core.ApiResponse;
using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Character.AddClassToCharacter;

public class AddClassToCharacterCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public Guid ClassId { get; set; }
    public int Level { get; set; } = 1;
    public List<string>? ChosenSkills { get; set; }
    public List<int>? RolledHitPoints { get; set; }
}

public class AddClassToCharacterCommandHandler : IRequestHandler<AddClassToCharacterCommand, ApiResponse<bool>>
{
    private readonly ICharacterRpcClient _client;
    public AddClassToCharacterCommandHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(AddClassToCharacterCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.AddClassToCharacter(request, request.Token!);
        return result.ToApiResponse(x => x, "Error adding class");
    }
}
