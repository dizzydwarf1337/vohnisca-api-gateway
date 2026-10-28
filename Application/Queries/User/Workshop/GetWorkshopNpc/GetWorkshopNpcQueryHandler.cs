using Application.Core.ApiResponse;
using Application.Core.Responses;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Workshop.GetWorkshopNpc;

public class GetWorkshopNpcQueryHandler : IRequestHandler<GetWorkshopNpcQuery, ApiResponse<WorkshopNpcDetail>>
{
    private readonly IWorkshopRpcClient _client;
    public GetWorkshopNpcQueryHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<WorkshopNpcDetail>> Handle(GetWorkshopNpcQuery request, CancellationToken cancellationToken)
        => (await _client.GetWorkshopNpc(request, request.Token!)).ToApiResponse(x => x, "Error loading the NPC");
}
