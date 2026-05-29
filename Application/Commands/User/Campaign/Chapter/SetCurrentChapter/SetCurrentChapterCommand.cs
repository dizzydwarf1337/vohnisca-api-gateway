using Application.Core.Mediatr.Requests.UserRequest;
using MediatR;

namespace Application.Commands.User.Campaign.Chapter.SetCurrentChapter;

public class SetCurrentChapterCommand : UserRequest<Unit>
{
    public required string CampaignId { get; set; }
    public required string ChapterId { get; set; }
}