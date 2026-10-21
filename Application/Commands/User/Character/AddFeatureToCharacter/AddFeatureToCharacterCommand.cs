using Application.Core.Mediatr.Requests.UserRequest;

namespace Application.Commands.User.Character.AddFeatureToCharacter;

public class AddFeatureToCharacterCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public Guid FeatureId { get; set; }
}
