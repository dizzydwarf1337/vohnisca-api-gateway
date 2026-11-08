using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Discussion.EditPost;

// The author (or a game master) changes a message; the service keeps the previous version in the history.
public class EditPostCommand : UserRequest<PostData>
{
    public Guid PostId { get; set; }
    public string Body { get; set; }
    public string? BodyFormat { get; set; }
}