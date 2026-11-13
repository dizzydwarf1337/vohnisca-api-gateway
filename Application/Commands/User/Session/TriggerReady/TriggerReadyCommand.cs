using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.TriggerReady;

// The GM: the trigger a creature readied for happens (TriggerTokenId: the creature that set it off).
public class TriggerReadyCommand : UserRequest<CombatResultData>
{
    public Guid SessionId { get; set; }
    public Guid TokenId { get; set; }
    public Guid? TriggerTokenId { get; set; }
}
