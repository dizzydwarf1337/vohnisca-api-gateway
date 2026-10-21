using Application.Core.ApiResponse;
using Application.Core.Responses;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Catalog.ListItems;

public class ListItemsQueryHandler : IRequestHandler<ListItemsQuery, ApiResponse<PaginationResponse<ItemListRow>>>
{
    private readonly ICharacterRpcClient _client;
    public ListItemsQueryHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<PaginationResponse<ItemListRow>>> Handle(ListItemsQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.ListItems(request.Page, request.PageSize, request.Token!);
        return result.ToApiResponse(x => x, "Error listing items");
    }
}
