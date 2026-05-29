using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Campaign.UpdateCampaign;

public class UpdateCampaignCommand : UserRequest<CampaignData>
{
    public string? CampaignId { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public string? Status { get; set; }
}