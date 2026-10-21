using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Character.GetCharacterShares;

public class GetCharacterSharesQuery : UserRequest<List<CharacterShareRow>>
{
    public Guid CharacterId { get; set; }
}
