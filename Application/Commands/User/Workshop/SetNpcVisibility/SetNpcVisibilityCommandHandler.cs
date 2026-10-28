using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Workshop.SetNpcVisibility;

public class SetNpcVisibilityCommandHandler : IRequestHandler<SetNpcVisibilityCommand, ApiResponse<bool>>
{
    private readonly IWorkshopRpcClient _client;
    public SetNpcVisibilityCommandHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(SetNpcVisibilityCommand request, CancellationToken cancellationToken)
        => (await _client.SetNpcVisibility(request, request.Token!)).ToApiResponse(x => x, "Error changing the NPC visibility");
}
