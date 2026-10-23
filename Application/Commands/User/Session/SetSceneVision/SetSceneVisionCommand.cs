using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.SetSceneVision;

// The GM's sight for the scene: Mode "off" | "manual" | "auto"; Light "bright" | "dim" | "dark"; how far anyone sees (null: the whole map).
public class SetSceneVisionCommand : UserRequest<SessionSceneData>
{
    public Guid SessionId { get; set; }
    public string Mode { get; set; } = "manual";
    public string Light { get; set; } = "bright";
    public int? RangeFeet { get; set; }
}
