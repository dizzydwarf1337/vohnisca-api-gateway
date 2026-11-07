using Application.Core.Mediatr.Requests.UserRequest;
using Application.Core.Validation;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Stash.SetTreasury;

// The one treasury route does both directions: Operation says whether the coins are put in or taken out,
// and the gateway picks the RPC (the campaign service has one method per direction).
public class SetTreasuryCommand : UserRequest<StashData>
{
    public Guid CardId { get; set; }
    public string Operation { get; set; } = StashTreasuryOperations.Add;
    public Dictionary<string, int> Coins { get; set; } = [];
}