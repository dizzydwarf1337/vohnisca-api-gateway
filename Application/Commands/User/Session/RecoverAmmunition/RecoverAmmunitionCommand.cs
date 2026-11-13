using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.RecoverAmmunition;

// The GM, after a fight: half the ammunition fired is gathered back in a minute (SRD 5.2).
public class RecoverAmmunitionCommand : UserRequest<CombatResultData>
{
    public Guid SessionId { get; set; }
}
