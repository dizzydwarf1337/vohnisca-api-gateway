using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.UseDoor;

public class UseDoorCommandHandler : IRequestHandler<UseDoorCommand, ApiResponse<SessionData>>
{
    private readonly ISessionRpcClient _client;
    public UseDoorCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionData>> Handle(UseDoorCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.UseDoor(request, request.Token!);
        return result.ToApiResponse(x => x, "Error using the door");
    }
}
