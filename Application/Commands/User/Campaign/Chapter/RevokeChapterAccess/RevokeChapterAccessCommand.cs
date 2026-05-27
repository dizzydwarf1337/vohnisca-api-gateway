using Application.Core.Mediatr.Requests.UserRequest;
using MediatR;

namespace Application.Commands.User.Campaign.Chapter.RevokeChapterAccess;

public class RevokeChapterAccessCommand : UserRequest<Unit>
{
    public string ChapterId { get; set; } = string.Empty;
    public string TargetUserId { get; set; } = string.Empty;
}