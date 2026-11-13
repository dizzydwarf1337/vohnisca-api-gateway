using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.Utilize;

// Utilize: an object used, as the player says.
public class UtilizeCommand : UserRequest<CombatResultData>
{
    public Guid SessionId { get; set; }
    public Guid TokenId { get; set; }
    public Guid? ItemId { get; set; }
    public string What { get; set; } = string.Empty;
}
