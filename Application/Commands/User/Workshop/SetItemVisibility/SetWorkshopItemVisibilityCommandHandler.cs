using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Workshop.SetItemVisibility;

public class SetWorkshopItemVisibilityCommandHandler : IRequestHandler<SetWorkshopItemVisibilityCommand, ApiResponse<bool>>
{
    private readonly IWorkshopRpcClient _client;
    public SetWorkshopItemVisibilityCommandHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(SetWorkshopItemVisibilityCommand request, CancellationToken cancellationToken)
        => (await _client.SetItemVisibility(request, request.Token!)).ToApiResponse(x => x, "Error changing item visibility");
}
