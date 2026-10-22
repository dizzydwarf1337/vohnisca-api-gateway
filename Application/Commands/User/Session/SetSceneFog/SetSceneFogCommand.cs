using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.SetSceneFog;

// The GM turns the fog on or off.
public class SetSceneFogCommand : UserRequest<SessionSceneData>
{
    public Guid SessionId { get; set; }
    public bool Fog { get; set; }
}
