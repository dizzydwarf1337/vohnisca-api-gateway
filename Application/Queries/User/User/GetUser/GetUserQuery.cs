using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.User.GetUser;

public class GetUserQuery : UserRequest<UserData>
{
    public Guid Id { get; set; }
}