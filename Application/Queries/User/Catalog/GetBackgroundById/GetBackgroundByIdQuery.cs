using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Catalog.GetBackgroundById;

public class GetBackgroundByIdQuery : UserRequest<BackgroundDetail>
{
    public Guid Id { get; set; }
}
