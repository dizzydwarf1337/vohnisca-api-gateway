using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Workshop.SetSpellVisibility;

public class SetWorkshopSpellVisibilityCommandHandler : IRequestHandler<SetWorkshopSpellVisibilityCommand, ApiResponse<bool>>
{
    private readonly IWorkshopRpcClient _client;
    public SetWorkshopSpellVisibilityCommandHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(SetWorkshopSpellVisibilityCommand request, CancellationToken cancellationToken)
        => (await _client.SetSpellVisibility(request, request.Token!)).ToApiResponse(x => x, "Error changing spell visibility");
}
