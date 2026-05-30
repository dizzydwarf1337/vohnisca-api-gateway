using Application.Core.Mediatr.Requests.UserRequest;
using MediatR;

namespace Application.Commands.User.Campaign.Note.DeleteNote;

public class DeleteNoteCommand : UserRequest<Unit>
{
    public Guid NoteId { get; set; }
}