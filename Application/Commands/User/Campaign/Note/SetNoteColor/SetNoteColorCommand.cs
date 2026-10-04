using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Note.SetNoteColor;

public class SetNoteColorCommand : UserRequest<NoteData>
{
    public Guid NoteId { get; set; }
    public string? BackgroundColor { get; set; }
}
