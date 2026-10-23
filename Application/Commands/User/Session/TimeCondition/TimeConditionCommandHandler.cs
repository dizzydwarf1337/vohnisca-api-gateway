using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.TimeCondition;

public class TimeConditionCommandHandler : IRequestHandler<TimeConditionCommand, ApiResponse<SessionData>>
{
    private readonly ISessionRpcClient _client;
    public TimeConditionCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionData>> Handle(TimeConditionCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.TimeCondition(request, request.Token!);
        return result.ToApiResponse(x => x, "Error timing the condition");
    }
}
