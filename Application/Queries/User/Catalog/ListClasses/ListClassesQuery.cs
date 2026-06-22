using Application.Core.ApiResponse;
using Application.Core.Mediatr.Requests.UserRequest;
using Application.Core.Responses;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Catalog.ListClasses;

public class ListClassesQuery : UserRequest<PaginationResponse<ClassListRow>>
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 100;
}

public class ListClassesQueryHandler : IRequestHandler<ListClassesQuery, ApiResponse<PaginationResponse<ClassListRow>>>
{
    private readonly ICharacterRpcClient _client;
    public ListClassesQueryHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<PaginationResponse<ClassListRow>>> Handle(ListClassesQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.ListClasses(request.Page, request.PageSize, request.Token!);
        return result.ToApiResponse(x => x, "Error listing classes");
    }
}
