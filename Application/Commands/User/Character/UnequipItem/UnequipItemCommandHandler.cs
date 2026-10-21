using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Character.UnequipItem;

public class UnequipItemCommandHandler : IRequestHandler<UnequipItemCommand, ApiResponse<bool>>
{
    private readonly ICharacterRpcClient _client;
    public UnequipItemCommandHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(UnequipItemCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.UnequipItem(request, request.Token!);
        return result.ToApiResponse(x => x, "Error unequipping item");
    }
}
