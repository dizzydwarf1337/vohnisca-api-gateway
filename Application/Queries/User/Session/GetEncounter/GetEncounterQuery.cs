using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Session.GetEncounter;

// The fight going on, as the user may see it.
public class GetEncounterQuery : UserRequest<SessionEncounterData>
{
    public Guid SessionId { get; set; }
}
