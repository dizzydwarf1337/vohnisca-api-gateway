using Application.Core.Mediatr.Requests.UserRequest;

namespace Application.Commands.User.Character.SpendCharacterMoney;

public class SpendCharacterMoneyCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public int Copper { get; set; }
    public int Silver { get; set; }
    public int Electrum { get; set; }
    public int Gold { get; set; }
    public int Platinum { get; set; }
}
