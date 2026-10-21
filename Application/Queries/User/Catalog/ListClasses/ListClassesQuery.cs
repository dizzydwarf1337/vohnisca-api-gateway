using Application.Core.Mediatr.Requests.UserRequest;
using Application.Core.Responses;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Catalog.ListClasses;

public class ListClassesQuery : UserRequest<PaginationResponse<ClassListRow>>
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 100;
}
