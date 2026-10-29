using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.SetSessionJoinable;

public class SetSessionJoinableCommandHandler : IRequestHandler<SetSessionJoinableCommand, ApiResponse<SessionData>>
{
    private readonly ISessionRpcClient _client;
    public SetSessionJoinableCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionData>> Handle(SetSessionJoinableCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.SetSessionJoinable(request, request.Token!);
        return result.ToApiResponse(x => x, "Error opening or closing the session");
    }
}
