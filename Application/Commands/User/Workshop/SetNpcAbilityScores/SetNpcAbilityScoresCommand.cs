using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Workshop.SetNpcAbilityScores;

public class SetNpcAbilityScoresCommand : UserRequest<bool>
{
    public Guid NpcId { get; set; }
    public Dictionary<string, int> AbilityScores { get; set; } = new();
}
