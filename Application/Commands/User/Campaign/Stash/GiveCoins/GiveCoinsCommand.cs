using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Stash.GiveCoins;

// The game master hands coins from the stash to a character: the transfer itself travels as an event
// (stage 04 wiring), the card answers with its remaining treasury.
public class GiveCoinsCommand : UserRequest<StashData>
{
    public Guid CardId { get; set; }
    public Guid CharacterId { get; set; }
    public Dictionary<string, int> Coins { get; set; } = [];
}