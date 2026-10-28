using Application.Core.Mediatr.Requests.UserRequest;
using Application.Core.Responses;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Workshop.GetWorkshopMap;

public class GetWorkshopMapQuery : UserRequest<WorkshopMapRow>
{
    public Guid Id { get; set; }
}
