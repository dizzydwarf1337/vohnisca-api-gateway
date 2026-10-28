using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Workshop.RemoveNpcAction;

public class RemoveNpcActionCommandHandler : IRequestHandler<RemoveNpcActionCommand, ApiResponse<bool>>
{
    private readonly IWorkshopRpcClient _client;
    public RemoveNpcActionCommandHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(RemoveNpcActionCommand request, CancellationToken cancellationToken)
        => (await _client.RemoveNpcAction(request, request.Token!)).ToApiResponse(x => x, "Error removing the action");
}
