using Application.Core.Mediatr.Requests.UserRequest;

namespace Application.Commands.User.Character.ShareCharacter;

public class ShareCharacterCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Access { get; set; } = string.Empty;
}
