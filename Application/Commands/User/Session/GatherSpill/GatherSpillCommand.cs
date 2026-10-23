using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.GatherSpill;

// A character gathers spilled Caltrops or Ball Bearings back (out of a fight).
public class GatherSpillCommand : UserRequest<SessionData>
{
    public Guid SessionId { get; set; }
    public Guid CharacterId { get; set; }
    public Guid TerrainId { get; set; }
}
