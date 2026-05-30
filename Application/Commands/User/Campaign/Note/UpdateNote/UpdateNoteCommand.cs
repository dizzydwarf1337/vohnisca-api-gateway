using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Note.UpdateNote;

public class UpdateNoteCommand : UserRequest<NoteData>
{
    public Guid NoteId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}