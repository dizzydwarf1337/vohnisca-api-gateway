using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Campaign.Note.GetNote;

public class GetNoteQuery : UserRequest<NoteData>
{
    public Guid NoteId { get; set; }
}