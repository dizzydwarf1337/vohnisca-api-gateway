using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Note.CreateNote;

public class CreateNoteCommand : UserRequest<NoteData>
{
    public Guid ChapterId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}