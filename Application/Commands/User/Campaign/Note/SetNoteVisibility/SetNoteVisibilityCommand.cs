using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Note.SetNoteVisibility;

public class SetNoteVisibilityCommand : UserRequest<NoteData>
{
    public Guid NoteId { get; set; }
    public bool IsPublic { get; set; }
}