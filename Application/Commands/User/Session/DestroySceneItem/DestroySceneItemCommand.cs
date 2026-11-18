using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.DestroySceneItem;

// I-03: the GM destroys a tracked item lying at the table — an explicit act; removing its token doesn't.
public class DestroySceneItemCommand : UserRequest<SessionSceneData>
{
    public Guid SessionId { get; set; }
    public Guid InstanceId { get; set; }
}
