using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Card.CreateNpcCard;

public class CreateNpcCardCommandHandler : IRequestHandler<CreateNpcCardCommand, ApiResponse<CampaignCardData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public CreateNpcCardCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<CampaignCardData>> Handle(CreateNpcCardCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.CreateNpcCard(
            request.CampaignId, request.ChapterId, request.RefId, request.Title,
            request.Content, request.ContentFormat, request.Token);
        return result.ToApiResponse(x => x.Card, "Error creating npc card");
    }
}