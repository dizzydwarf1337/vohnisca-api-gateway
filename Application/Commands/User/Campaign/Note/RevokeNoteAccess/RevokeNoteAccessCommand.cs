using Application.Core.Mediatr.Requests.UserRequest;
using MediatR;

namespace Application.Commands.User.Campaign.Note.RevokeNoteAccess;

public class RevokeNoteAccessCommand : UserRequest<Unit>
{
    public Guid NoteId { get; set; }
    public Guid TargetUserId { get; set; }
}