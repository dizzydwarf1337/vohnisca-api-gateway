using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.PlaceWorkshopNpc;

// The GM puts a workshop NPC on the map, with its stat block (Team: its side, null: hostile).
public class PlaceWorkshopNpcCommand : UserRequest<SessionSceneData>
{
    public Guid SessionId { get; set; }
    public Guid NpcId { get; set; }
    public int Col { get; set; }
    public int Row { get; set; }
    public bool Hidden { get; set; }
    public string? Team { get; set; }
}
