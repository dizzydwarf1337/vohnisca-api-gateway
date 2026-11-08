using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Workshop.RollNpcDraft;

// A random NPC the master corrects in the form before saving: the workshop rolls it out of the
// catalog and saves nothing. role: bestiary | character; raceId/classId/level narrow the
// character half.
public class RollNpcDraftQuery : UserRequest<WorkshopNpcDraft>
{
    public string Role { get; set; } = "bestiary";
    public Guid? RaceId { get; set; }
    public Guid? ClassId { get; set; }
    public int? Level { get; set; }
}
