using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.RollDice;

// A roll at the table, made on the server.
public class RollDiceCommand : UserRequest<DiceRollData>
{
    public Guid SessionId { get; set; }
    // Dice notation: "2d6+3", "1d20+5", "2d20kh1" (advantage).
    public string Expression { get; set; } = string.Empty;
    public string? Label { get; set; }
    // Only the GM and the roller see it.
    public bool Secret { get; set; }
}
