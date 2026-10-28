using Application.Core.ApiResponse;
using Application.Core.Responses;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Workshop.ListWorkshopMaps;

public class ListWorkshopMapsQueryHandler : IRequestHandler<ListWorkshopMapsQuery, ApiResponse<PaginationResponse<WorkshopMapRow>>>
{
    private readonly IWorkshopRpcClient _client;
    public ListWorkshopMapsQueryHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<PaginationResponse<WorkshopMapRow>>> Handle(ListWorkshopMapsQuery request, CancellationToken cancellationToken)
        => (await _client.ListWorkshopMaps(request, request.Token!)).ToApiResponse(x => x, "Error listing maps");
}
