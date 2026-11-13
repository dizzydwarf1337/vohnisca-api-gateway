using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.Study;

public class StudyCommandHandler : IRequestHandler<StudyCommand, ApiResponse<CombatResultData>>
{
    private readonly ISessionRpcClient _client;
    public StudyCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<CombatResultData>> Handle(StudyCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.Study(request, request.Token!);
        return result.ToApiResponse(x => x, "Error: Study");
    }
}
