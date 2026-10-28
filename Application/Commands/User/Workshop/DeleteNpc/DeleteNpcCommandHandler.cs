using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Workshop.DeleteNpc;

public class DeleteNpcCommandHandler : IRequestHandler<DeleteNpcCommand, ApiResponse<bool>>
{
    private readonly IWorkshopRpcClient _client;
    public DeleteNpcCommandHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(DeleteNpcCommand request, CancellationToken cancellationToken)
        => (await _client.DeleteNpc(request, request.Token!)).ToApiResponse(x => x, "Error deleting the NPC");
}
