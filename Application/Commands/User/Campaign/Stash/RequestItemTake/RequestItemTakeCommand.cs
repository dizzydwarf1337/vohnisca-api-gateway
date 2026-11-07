using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Stash.RequestItemTake;

// A player asks to take something out of a stash for their own character. The campaign service cannot
// see characters, so the ownership check lives here: the character sheet says how the caller relates to
// the character, and only an owner may ask for themselves.
public class RequestItemTakeCommand : UserRequest<ItemRequestData>
{
    public Guid CardId { get; set; }
    public Guid CharacterId { get; set; }
}