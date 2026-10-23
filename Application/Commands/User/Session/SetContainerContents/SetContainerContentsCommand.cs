using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.SetContainerContents;

// The GM fills a container: all it holds, replacing what was there.
public class SetContainerContentsCommand : UserRequest<SessionSceneData>
{
    public Guid SessionId { get; set; }
    public Guid TokenId { get; set; }
    public List<ContentRowData> Contents { get; set; } = [];
}
