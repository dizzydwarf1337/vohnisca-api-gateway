using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Character.DestroyItem;

public class DestroyItemCommandHandler : IRequestHandler<DestroyItemCommand, ApiResponse<bool>>
{
    private readonly ICharacterRpcClient _client;
    public DestroyItemCommandHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(DestroyItemCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.DestroyItem(request, request.Token!);
        return result.ToApiResponse(x => x, "Error destroying item");
    }
}
