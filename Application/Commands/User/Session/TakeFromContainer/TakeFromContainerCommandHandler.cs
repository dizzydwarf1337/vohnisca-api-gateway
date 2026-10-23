using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.TakeFromContainer;

public class TakeFromContainerCommandHandler : IRequestHandler<TakeFromContainerCommand, ApiResponse<SessionData>>
{
    private readonly ISessionRpcClient _client;
    public TakeFromContainerCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionData>> Handle(TakeFromContainerCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.TakeFromContainer(request, request.Token!);
        return result.ToApiResponse(x => x, "Error taking from the container");
    }
}
