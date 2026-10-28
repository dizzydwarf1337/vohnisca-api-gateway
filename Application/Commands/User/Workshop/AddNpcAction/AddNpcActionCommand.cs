using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Workshop.AddNpcAction;

// An action; with AttackBonus and damage dice it is an attack at the table.
public class AddNpcActionCommand : UserRequest<NpcActionAdded>
{
    public Guid NpcId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int? AttackBonus { get; set; }
    public int? DamageDiceCount { get; set; }
    public string? DamageDiceType { get; set; }
    public string? DamageType { get; set; }
    public int? DamageBonus { get; set; }
    public string? Range { get; set; }
}
