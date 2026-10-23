using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.SetContainerContents;

public class SetContainerContentsCommandHandler : IRequestHandler<SetContainerContentsCommand, ApiResponse<SessionSceneData>>
{
    private readonly ISessionRpcClient _client;
    public SetContainerContentsCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionSceneData>> Handle(SetContainerContentsCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.SetContainerContents(request, request.Token!);
        return result.ToApiResponse(x => x, "Error filling the container");
    }
}
