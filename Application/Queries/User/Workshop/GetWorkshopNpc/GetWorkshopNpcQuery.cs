using Application.Core.Mediatr.Requests.UserRequest;
using Application.Core.Responses;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Workshop.GetWorkshopNpc;

public class GetWorkshopNpcQuery : UserRequest<WorkshopNpcDetail>
{
    public Guid Id { get; set; }
}
