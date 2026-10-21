using Application.Core.Mediatr.Requests.UserRequest;

namespace Application.Commands.User.Character.DeleteCharacter;

public class DeleteCharacterCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
}
