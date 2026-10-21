using Application.Core.Mediatr.Requests.UserRequest;

namespace Application.Commands.User.Character.ChangeCharacterSubRace;

public class ChangeCharacterSubRaceCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public Guid? SubRaceId { get; set; }
}
