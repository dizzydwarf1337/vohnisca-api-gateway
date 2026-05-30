using Application.Core.Mediatr.Requests.UserRequest;
using MediatR;

namespace Application.Commands.User.Campaign.Chapter.DeleteChapter;

public class DeleteChapterCommand : UserRequest<Unit>
{
    public Guid ChapterId { get; set; }
}