using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Session.GetDiceRolls;

// The latest rolls at the table this user may see.
public class GetDiceRollsQuery : UserRequest<DiceRollsData>
{
    public Guid SessionId { get; set; }
}
