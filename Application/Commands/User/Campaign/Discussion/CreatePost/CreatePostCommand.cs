using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Discussion.CreatePost;

// A message in a thread: plain text (the service stores it as it comes, up to 10 000 characters) and an
// optional answer to another message.
public class CreatePostCommand : UserRequest<PostData>
{
    public Guid ThreadId { get; set; }
    public string Body { get; set; }
    public Guid? ReplyToId { get; set; }
}