using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Workshop.UpdateItem;

public class UpdateWorkshopItemCommandHandler : IRequestHandler<UpdateWorkshopItemCommand, ApiResponse<bool>>
{
    private readonly IWorkshopRpcClient _client;
    public UpdateWorkshopItemCommandHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(UpdateWorkshopItemCommand request, CancellationToken cancellationToken)
        => (await _client.UpdateItem(request, request.Token!)).ToApiResponse(x => x, "Error updating item");
}
