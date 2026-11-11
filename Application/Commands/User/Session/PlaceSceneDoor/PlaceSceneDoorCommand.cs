using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.PlaceSceneDoor;

// The GM sets a door on a square, or in a side of it (Place), or takes it away.
public class PlaceSceneDoorCommand : UserRequest<SessionSceneData>
{
    public Guid SessionId { get; set; }
    public int Col { get; set; }
    public int Row { get; set; }
    public bool Place { get; set; }
    // "n" | "e" | "s" | "w": a thin door set in that side of the square (the square stays free);
    // none: a door that takes the square.
    public string? Side { get; set; }
    // How it looks: "wood" | "iron" | "stone".
    public string? Material { get; set; }
}
