using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.SetVisionGroups;

// The GM's groups of characters that share what they see (automatic sight).
public class SetVisionGroupsCommand : UserRequest<SessionData>
{
    public Guid SessionId { get; set; }
    public List<VisionGroupInputData> Groups { get; set; } = [];
}
