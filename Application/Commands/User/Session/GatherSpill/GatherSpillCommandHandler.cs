using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.GatherSpill;

public class GatherSpillCommandHandler : IRequestHandler<GatherSpillCommand, ApiResponse<SessionData>>
{
    private readonly ISessionRpcClient _client;
    public GatherSpillCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionData>> Handle(GatherSpillCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.GatherSpill(request, request.Token!);
        return result.ToApiResponse(x => x, "Error gathering them");
    }
}
