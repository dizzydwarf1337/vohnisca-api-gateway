using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.SetShortRest;

public class SetShortRestCommandHandler : IRequestHandler<SetShortRestCommand, ApiResponse<SessionData>>
{
    private readonly ISessionRpcClient _client;
    public SetShortRestCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionData>> Handle(SetShortRestCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.SetShortRest(request, request.Token!);
        return result.ToApiResponse(x => x, "Error changing the rest");
    }
}
