using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.AnswerReaction;

// A reaction on offer, taken (OptionId: how) or let pass (no OptionId).
public class AnswerReactionCommand : UserRequest<CombatResultData>
{
    public Guid SessionId { get; set; }
    public Guid OfferId { get; set; }
    public string? OptionId { get; set; }
}
