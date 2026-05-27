using Application.Core.Mediatr.Requests.UserRequest;
using MediatR;

namespace Application.Commands.User.Campaign.Note.RevokeNoteAccess;

public class RevokeNoteAccessCommand : UserRequest<Unit>
{
    public string NoteId { get; set; }
    public string TargetUserId { get; set; }
}