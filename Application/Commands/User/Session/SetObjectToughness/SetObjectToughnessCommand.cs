using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.SetObjectToughness;

// How tough a door or a chest is as an object: its Armor Class and Hit Points.
public class SetObjectToughnessCommand : UserRequest<SessionSceneData>
{
    public Guid SessionId { get; set; }
    public Guid TargetId { get; set; }
    public int Ac { get; set; }
    public int MaxHp { get; set; }
}
