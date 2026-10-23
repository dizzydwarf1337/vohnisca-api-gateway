using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.SetSceneVision;

public class SetSceneVisionCommandHandler : IRequestHandler<SetSceneVisionCommand, ApiResponse<SessionSceneData>>
{
    private readonly ISessionRpcClient _client;
    public SetSceneVisionCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionSceneData>> Handle(SetSceneVisionCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.SetSceneVision(request, request.Token!);
        return result.ToApiResponse(x => x, "Error setting the sight");
    }
}
