using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Character.GetCreationOptions;

// Level 1 creation choices for the picked class, background and species, given the
// choices made so far.
public class GetCreationOptionsQuery : UserRequest<List<CreationChoiceRow>>
{
    // Any pick may still be missing; only the parts picked so far are described.
    public Guid? ClassId { get; set; }
    public Guid? RaceId { get; set; }
    public Guid? SubRaceId { get; set; }
    public Guid? BackgroundId { get; set; }
    public Dictionary<string, List<string>> Choices { get; set; } = new();
}
