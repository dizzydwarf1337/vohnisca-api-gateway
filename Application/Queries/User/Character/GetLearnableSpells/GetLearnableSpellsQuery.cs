using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Character.GetLearnableSpells;

public class GetLearnableSpellsQuery : UserRequest<List<LearnableSpellClassRow>>
{
    public Guid CharacterId { get; set; }
}
