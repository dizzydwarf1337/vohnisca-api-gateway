using Application.Core.ApiResponse;
using Application.Core.Responses;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Catalog.ListClasses;

public class ListClassesQueryHandler : IRequestHandler<ListClassesQuery, ApiResponse<PaginationResponse<ClassListRow>>>
{
    private readonly IWorkshopRpcClient _client;
    public ListClassesQueryHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<PaginationResponse<ClassListRow>>> Handle(ListClassesQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.ListClasses(request.Page, request.PageSize, request.Token!);
        return result.ToApiResponse(x => x, "Error listing classes");
    }
}
