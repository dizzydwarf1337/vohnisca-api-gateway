using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.AnswerReaction;

public class AnswerReactionCommandHandler : IRequestHandler<AnswerReactionCommand, ApiResponse<CombatResultData>>
{
    private readonly ISessionRpcClient _client;
    public AnswerReactionCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<CombatResultData>> Handle(AnswerReactionCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.AnswerReaction(request, request.Token!);
        return result.ToApiResponse(x => x, "Error answering the reaction");
    }
}
