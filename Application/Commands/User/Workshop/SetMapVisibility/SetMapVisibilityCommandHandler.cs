using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Workshop.SetMapVisibility;

public class SetMapVisibilityCommandHandler : IRequestHandler<SetMapVisibilityCommand, ApiResponse<bool>>
{
    private readonly IWorkshopRpcClient _client;
    public SetMapVisibilityCommandHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(SetMapVisibilityCommand request, CancellationToken cancellationToken)
        => (await _client.SetMapVisibility(request, request.Token!)).ToApiResponse(x => x, "Error changing the map visibility");
}
