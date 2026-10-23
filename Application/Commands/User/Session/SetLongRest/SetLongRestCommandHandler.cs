using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.SetLongRest;

public class SetLongRestCommandHandler : IRequestHandler<SetLongRestCommand, ApiResponse<SessionData>>
{
    private readonly ISessionRpcClient _client;
    public SetLongRestCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionData>> Handle(SetLongRestCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.SetLongRest(request, request.Token!);
        return result.ToApiResponse(x => x, "Error changing the rest");
    }
}
