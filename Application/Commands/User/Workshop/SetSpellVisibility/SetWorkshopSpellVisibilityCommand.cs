using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Workshop.SetSpellVisibility;

public class SetWorkshopSpellVisibilityCommand : UserRequest<bool>
{
    public Guid SpellId { get; set; }
    public string Visibility { get; set; } = "Private";
}
