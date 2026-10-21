using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Catalog.GetRaceById;

public class GetRaceByIdQuery : UserRequest<RaceDetail>
{
    public Guid Id { get; set; }
}
