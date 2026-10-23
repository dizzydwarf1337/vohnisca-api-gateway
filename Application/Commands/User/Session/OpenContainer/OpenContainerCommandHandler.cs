using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.OpenContainer;

public class OpenContainerCommandHandler : IRequestHandler<OpenContainerCommand, ApiResponse<SessionData>>
{
    private readonly ISessionRpcClient _client;
    public OpenContainerCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionData>> Handle(OpenContainerCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.OpenContainer(request, request.Token!);
        return result.ToApiResponse(x => x, "Error opening the container");
    }
}
