using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Catalog.GetClassById;

public class GetClassByIdQuery : UserRequest<ClassDetail>
{
    public Guid Id { get; set; }
}
