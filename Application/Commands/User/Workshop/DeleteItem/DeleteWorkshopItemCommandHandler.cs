using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Workshop.DeleteItem;

public class DeleteWorkshopItemCommandHandler : IRequestHandler<DeleteWorkshopItemCommand, ApiResponse<bool>>
{
    private readonly IWorkshopRpcClient _client;
    public DeleteWorkshopItemCommandHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(DeleteWorkshopItemCommand request, CancellationToken cancellationToken)
        => (await _client.DeleteItem(request, request.Token!)).ToApiResponse(x => x, "Error deleting item");
}
