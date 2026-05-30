using Application.Core.Mediatr.Requests.UserRequest;
using MediatR;

namespace Application.Commands.User.Campaign.Campaign.DeleteCampaign;

public class DeleteCampaignCommand : UserRequest<Unit>
{
    public Guid CampaignId { get; set; }
}