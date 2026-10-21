using Application.Core.Mediatr.Requests.UserRequest;

namespace Application.Commands.User.Character.RenameCharacter;

public class RenameCharacterCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public string Name { get; set; } = string.Empty;
}
