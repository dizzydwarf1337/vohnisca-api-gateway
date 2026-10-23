using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.PutIntoContainer;

public class PutIntoContainerCommandHandler : IRequestHandler<PutIntoContainerCommand, ApiResponse<SessionData>>
{
    private readonly ISessionRpcClient _client;
    public PutIntoContainerCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionData>> Handle(PutIntoContainerCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.PutIntoContainer(request, request.Token!);
        return result.ToApiResponse(x => x, "Error putting it in");
    }
}
