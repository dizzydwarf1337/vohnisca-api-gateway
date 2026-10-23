using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.SetObjectToughness;

public class SetObjectToughnessCommandHandler : IRequestHandler<SetObjectToughnessCommand, ApiResponse<SessionSceneData>>
{
    private readonly ISessionRpcClient _client;
    public SetObjectToughnessCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionSceneData>> Handle(SetObjectToughnessCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.SetObjectToughness(request, request.Token!);
        return result.ToApiResponse(x => x, "Error setting how tough it is");
    }
}
