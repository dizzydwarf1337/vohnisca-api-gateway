using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.SetScene;

// The GM sets the scene: background, grid size and whether the fog is on.
public class SetSceneCommand : UserRequest<SessionSceneData>
{
    public Guid SessionId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Cols { get; set; }
    public int Rows { get; set; }
    public bool Fog { get; set; }
    // The background; kept from the current scene when not sent.
    public byte[]? Image { get; set; }
    public string? ImageContentType { get; set; }
}
