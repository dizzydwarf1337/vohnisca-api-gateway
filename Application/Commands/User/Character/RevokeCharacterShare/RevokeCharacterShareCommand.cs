using Application.Core.Mediatr.Requests.UserRequest;

namespace Application.Commands.User.Character.RevokeCharacterShare;

public class RevokeCharacterShareCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public string UserName { get; set; } = string.Empty;
}
