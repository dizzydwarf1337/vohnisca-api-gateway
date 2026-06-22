using Application.Core.ApiResponse;
using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Catalog.GetItemById;

public class GetItemByIdQuery : UserRequest<ItemDetail>
{
    public Guid Id { get; set; }
}

public class GetItemByIdQueryHandler : IRequestHandler<GetItemByIdQuery, ApiResponse<ItemDetail>>
{
    private readonly ICharacterRpcClient _client;
    public GetItemByIdQueryHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<ItemDetail>> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.GetItemById(request.Id, request.Token!);
        return result.ToApiResponse(x => x, "Error getting item");
    }
}
