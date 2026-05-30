using Application.Core.Mediatr.Requests.UserRequest;
using MediatR;

namespace Application.Commands.User.Campaign.Chapter.MoveChapter;

public class MoveChapterCommand : UserRequest<Unit>
{
    public Guid ChapterId { get; set; }
    public Guid NewParentId { get; set; }
}