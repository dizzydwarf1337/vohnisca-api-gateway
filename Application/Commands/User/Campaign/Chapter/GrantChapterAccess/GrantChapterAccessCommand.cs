using Application.Core.Mediatr.Requests.UserRequest;
using MediatR;

namespace Application.Commands.User.Campaign.Chapter.GrantChapterAccess;

public class GrantChapterAccessCommand : UserRequest<Unit>
{
    public Guid ChapterId { get; set; }
    public Guid[] TargetUserIds { get; set; } = [];
}