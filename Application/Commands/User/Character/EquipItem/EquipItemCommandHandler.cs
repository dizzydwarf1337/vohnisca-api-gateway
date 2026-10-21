using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Character.EquipItem;

public class EquipItemCommandHandler : IRequestHandler<EquipItemCommand, ApiResponse<bool>>
{
    private readonly ICharacterRpcClient _client;
    public EquipItemCommandHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(EquipItemCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.EquipItem(request, request.Token!);
        return result.ToApiResponse(x => x, "Error equipping item");
    }
}
