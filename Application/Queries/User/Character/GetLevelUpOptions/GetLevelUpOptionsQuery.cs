using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Character.GetLevelUpOptions;

// The choices gaining the next level of a class calls for, given the choices made so far.
public class GetLevelUpOptionsQuery : UserRequest<List<CreationChoiceRow>>
{
    public Guid CharacterId { get; set; }
    public Guid ClassId { get; set; }
    public Dictionary<string, List<string>> Choices { get; set; } = new();
}
