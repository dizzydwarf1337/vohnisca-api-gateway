using Application.Core.Mediatr.Requests.UserRequest;
using MediatR;

namespace Application.Commands.User.Campaign.Chapter.MoveChapter;

public class MoveChapterCommand : UserRequest<Unit>
{
    public string ChapterId { get; set; } = string.Empty;
    public string? NewParentId { get; set; }
}