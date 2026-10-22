using Application.Core.Mediatr.Requests.UserRequest;

namespace Application.Commands.User.Character.ReleaseCharacterSession;

// The owner takes the character back from a game session that never ended.
public class ReleaseCharacterSessionCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
}
