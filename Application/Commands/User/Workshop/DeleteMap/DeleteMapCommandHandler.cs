using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Workshop.DeleteMap;

public class DeleteMapCommandHandler : IRequestHandler<DeleteMapCommand, ApiResponse<bool>>
{
    private readonly IWorkshopRpcClient _client;
    public DeleteMapCommandHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(DeleteMapCommand request, CancellationToken cancellationToken)
        => (await _client.DeleteMap(request, request.Token!)).ToApiResponse(x => x, "Error deleting the map");
}
