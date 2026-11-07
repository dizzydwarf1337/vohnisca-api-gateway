using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Discussion.DeletePost;

// A soft delete: the message keeps its place in the thread with no text, so the discussion still reads.
public class DeletePostCommand : UserRequest<PostData>
{
    public Guid PostId { get; set; }
}