using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Workshop.DeleteSpell;

public class DeleteWorkshopSpellCommand : UserRequest<bool>
{
    public Guid SpellId { get; set; }
}
