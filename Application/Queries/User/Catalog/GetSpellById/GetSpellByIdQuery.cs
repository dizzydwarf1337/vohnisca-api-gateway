using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Catalog.GetSpellById;

public class GetSpellByIdQuery : UserRequest<SpellDetail>
{
    public Guid Id { get; set; }
}
