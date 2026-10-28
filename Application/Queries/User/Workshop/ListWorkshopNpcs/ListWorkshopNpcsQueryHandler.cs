using Application.Core.ApiResponse;
using Application.Core.Responses;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Workshop.ListWorkshopNpcs;

public class ListWorkshopNpcsQueryHandler : IRequestHandler<ListWorkshopNpcsQuery, ApiResponse<PaginationResponse<WorkshopNpcRow>>>
{
    private readonly IWorkshopRpcClient _client;
    public ListWorkshopNpcsQueryHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<PaginationResponse<WorkshopNpcRow>>> Handle(ListWorkshopNpcsQuery request, CancellationToken cancellationToken)
        => (await _client.ListWorkshopNpcs(request, request.Token!)).ToApiResponse(x => x, "Error listing NPCs");
}
