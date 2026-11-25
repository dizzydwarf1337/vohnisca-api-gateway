using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.SetRequireSpellComponents;

public class SetRequireSpellComponentsCommandHandler : IRequestHandler<SetRequireSpellComponentsCommand, ApiResponse<SessionData>>
{
    private readonly ISessionRpcClient _client;
    public SetRequireSpellComponentsCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionData>> Handle(SetRequireSpellComponentsCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.SetRequireSpellComponents(request, request.Token!);
        return result.ToApiResponse(x => x, "Error changing the session's setting");
    }
}
