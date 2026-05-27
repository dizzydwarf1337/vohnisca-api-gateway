using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Campaign.Note.GetNote;

public class GetNoteQuery : UserRequest<NoteData>
{
    public string NoteId { get; set; }
}