using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.SetVisionGroups;

public class SetVisionGroupsCommandHandler : IRequestHandler<SetVisionGroupsCommand, ApiResponse<SessionData>>
{
    private readonly ISessionRpcClient _client;
    public SetVisionGroupsCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionData>> Handle(SetVisionGroupsCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.SetVisionGroups(request, request.Token!);
        return result.ToApiResponse(x => x, "Error setting the vision groups");
    }
}
