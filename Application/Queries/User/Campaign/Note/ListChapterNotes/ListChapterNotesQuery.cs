using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Campaign.Note.ListChapterNotes;

public class ListChapterNotesQuery : UserRequest<List<NoteData>>
{
    public string ChapterId { get; set; }
}