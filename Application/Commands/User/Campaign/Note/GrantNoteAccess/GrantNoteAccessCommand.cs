using Application.Core.Mediatr.Requests.UserRequest;
using MediatR;

namespace Application.Commands.User.Campaign.Note.GrantNoteAccess;

public class GrantNoteAccessCommand : UserRequest<Unit>
{
    public string NoteId { get; set; }
    public required string TargetUserId { get; set; }
}