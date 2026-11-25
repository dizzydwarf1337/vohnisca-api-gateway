using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.SetRequireSpellComponents;

// F-02: the GM requires spells' Material components at the table, or not (Require Spell Components).
public class SetRequireSpellComponentsCommand : UserRequest<SessionData>
{
    public Guid SessionId { get; set; }
    public bool On { get; set; }
}
