using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Catalog.GetSpellInfo;

// A spell's details for a window; with a character, how it has the spell.
public class GetSpellInfoQuery : UserRequest<CatalogSpellInfo>
{
    public Guid SpellId { get; set; }
    public Guid? CharacterId { get; set; }
}
