using Application.Core.Mediatr.Requests.UserRequest;
using MediatR;

namespace Application.Commands.User.Campaign.Chapter.GrantChapterAccess;

public class GrantChapterAccessCommand : UserRequest<Unit>
{
    public string ChapterId { get; set; } = string.Empty;
    public required string TargetUserId { get; set; }
}