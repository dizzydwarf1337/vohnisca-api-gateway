using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Catalog.GetItemById;

public class GetItemByIdQueryHandler : IRequestHandler<GetItemByIdQuery, ApiResponse<ItemDetail>>
{
    private readonly IWorkshopRpcClient _client;
    public GetItemByIdQueryHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<ItemDetail>> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.GetItemById(request.Id, request.Token!);
        return result.ToApiResponse(x => x, "Error getting item");
    }
}
