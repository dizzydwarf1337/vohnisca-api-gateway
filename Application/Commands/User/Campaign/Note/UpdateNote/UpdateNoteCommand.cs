using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Note.UpdateNote;

public class UpdateNoteCommand : UserRequest<NoteData>
{
    public string NoteId { get; set; }
    public required string Title { get; set; }
    public string? Content { get; set; }
}