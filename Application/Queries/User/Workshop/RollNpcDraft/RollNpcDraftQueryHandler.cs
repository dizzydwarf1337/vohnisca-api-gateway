using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Workshop.RollNpcDraft;

public class RollNpcDraftQueryHandler : IRequestHandler<RollNpcDraftQuery, ApiResponse<WorkshopNpcDraft>>
{
    private readonly IWorkshopRpcClient _client;
    public RollNpcDraftQueryHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<WorkshopNpcDraft>> Handle(RollNpcDraftQuery request, CancellationToken cancellationToken)
        => (await _client.RollNpcDraft(request, request.Token!)).ToApiResponse(x => x, "Error rolling an NPC draft");
}
