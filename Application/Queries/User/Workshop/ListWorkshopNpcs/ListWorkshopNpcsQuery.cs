using Application.Core.Mediatr.Requests.UserRequest;
using Application.Core.Responses;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Workshop.ListWorkshopNpcs;

public class ListWorkshopNpcsQuery : UserRequest<PaginationResponse<WorkshopNpcRow>>
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 50;
    public bool Mine { get; set; }
}
