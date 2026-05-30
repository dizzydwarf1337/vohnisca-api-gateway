using Application.Core.Mediatr.Requests.UserRequest;
using MediatR;

namespace Application.Commands.User.Campaign.Note.GrantNoteAccess;

public class GrantNoteAccessCommand : UserRequest<Unit>
{
    public Guid NoteId { get; set; }
    public Guid TargetUserId { get; set; }
}