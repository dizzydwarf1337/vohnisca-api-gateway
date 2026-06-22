using Application.Core.ApiResponse;
using Application.Core.Mediatr.Requests.UserRequest;
using Application.Core.Responses;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Catalog.ListBackgrounds;

public class ListBackgroundsQuery : UserRequest<PaginationResponse<BackgroundListRow>>
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 100;
}

public class ListBackgroundsQueryHandler : IRequestHandler<ListBackgroundsQuery, ApiResponse<PaginationResponse<BackgroundListRow>>>
{
    private readonly ICharacterRpcClient _client;
    public ListBackgroundsQueryHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<PaginationResponse<BackgroundListRow>>> Handle(ListBackgroundsQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.ListBackgrounds(request.Page, request.PageSize, request.Token!);
        return result.ToApiResponse(x => x, "Error listing backgrounds");
    }
}
