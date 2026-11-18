using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.ResolveLastCharge;

// I-08: the GM's decision on a last charge the SRD leaves to the table: "keep" | "inert" | "destroy".
public class ResolveLastChargeCommand : UserRequest<SessionData>
{
    public Guid SessionId { get; set; }
    public Guid CharacterId { get; set; }
    public Guid InstanceId { get; set; }
    public string Decision { get; set; } = string.Empty;
}
