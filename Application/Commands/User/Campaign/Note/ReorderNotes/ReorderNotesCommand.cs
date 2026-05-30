using Application.Core.Mediatr.Requests.UserRequest;
using MediatR;

namespace Application.Commands.User.Campaign.Note.ReorderNotes;

public class ReorderNotesCommand : UserRequest<Unit>
{
    public Guid ChapterId { get; set; }
    public List<string> OrderedIds { get; set; } = [];
}