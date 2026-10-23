using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.SetTokenLight;

// A token's light: the GM sets Bright / Dim (feet); a player lights a Source its character carries ("Torch", "Lamp"...), or none to put it out.
public class SetTokenLightCommand : UserRequest<SessionSceneData>
{
    public Guid SessionId { get; set; }
    public Guid TokenId { get; set; }
    public int Bright { get; set; }
    public int Dim { get; set; }
    public string? Source { get; set; }
}
