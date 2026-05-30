using Application.Core.Mediatr.Requests.UserRequest;
using MediatR;

namespace Application.Commands.User.Campaign.Chapter.SetCurrentChapter;

public class SetCurrentChapterCommand : UserRequest<Unit>
{
    public Guid CampaignId { get; set; }
    public Guid ChapterId { get; set; }
}