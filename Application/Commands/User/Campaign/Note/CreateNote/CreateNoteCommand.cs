using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Note.CreateNote;

public class CreateNoteCommand : UserRequest<NoteData>
{
    public required string ChapterId { get; set; }
    public required string Title { get; set; }
    public string? Content { get; set; }
}