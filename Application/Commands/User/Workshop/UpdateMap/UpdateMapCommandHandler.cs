using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Workshop.UpdateMap;

public class UpdateMapCommandHandler : IRequestHandler<UpdateMapCommand, ApiResponse<bool>>
{
    private readonly IWorkshopRpcClient _client;
    public UpdateMapCommandHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(UpdateMapCommand request, CancellationToken cancellationToken)
        => (await _client.UpdateMap(request, request.Token!)).ToApiResponse(x => x, "Error updating the map");
}
