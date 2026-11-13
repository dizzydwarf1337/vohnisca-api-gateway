using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.GiveAway;

// The GM: a hider made a sound louder than a whisper — it stops being hidden (SRD 5.2, Hide).
public class GiveAwayCommand : UserRequest<CombatResultData>
{
    public Guid SessionId { get; set; }
    public Guid TokenId { get; set; }
}
