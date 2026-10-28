using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Workshop.SetNpcImage;

public class SetNpcImageCommandHandler : IRequestHandler<SetNpcImageCommand, ApiResponse<bool>>
{
    private readonly IWorkshopRpcClient _client;
    public SetNpcImageCommandHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(SetNpcImageCommand request, CancellationToken cancellationToken)
        => (await _client.SetNpcImage(request, request.Token!)).ToApiResponse(x => x, "Error setting the NPC image");
}
