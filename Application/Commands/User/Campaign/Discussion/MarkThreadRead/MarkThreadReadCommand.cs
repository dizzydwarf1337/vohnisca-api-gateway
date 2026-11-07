using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Discussion.MarkThreadRead;

// Marks the thread read up to now: the unread badges of the campaign are counted from these marks.
public class MarkThreadReadCommand : UserRequest<ThreadReadResponse>
{
    public Guid ThreadId { get; set; }
}