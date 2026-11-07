using Application.Core.Mediatr.Requests.UserRequest;
using Application.Core.Validation;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Discussion.CreateChapterThread;

// A topic of one chapter's forum. The route carries only the chapter, so the handler resolves its campaign
// first (the campaign service keys every thread by campaign).
public class CreateChapterThreadCommand : UserRequest<ThreadData>
{
    public Guid ChapterId { get; set; }
    public string Title { get; set; }
    public string Visibility { get; set; } = ThreadVisibilities.All;
}