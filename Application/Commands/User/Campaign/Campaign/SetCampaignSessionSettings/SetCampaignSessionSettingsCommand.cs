using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Campaign.SetCampaignSessionSettings;

// I-12, F-02: what the campaign's next session opens with; the master or a co-master sets it (the campaign service decides).
// A setting left out stays as it is.
public class SetCampaignSessionSettingsCommand : UserRequest<CampaignData>
{
    public Guid CampaignId { get; set; }
    public bool? CarryingAffectsMovement { get; set; }
    public bool? RequireSpellComponents { get; set; }
}
