using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Card.CreateItemCard;

public class CreateItemCardCommandHandler : IRequestHandler<CreateItemCardCommand, ApiResponse<CampaignCardData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public CreateItemCardCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<CampaignCardData>> Handle(CreateItemCardCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.CreateItemCard(
            request.CampaignId, request.ChapterId, request.RefId, request.Quantity,
            request.ContainerId, request.Title, request.Content, request.ContentFormat, request.Token);
        return result.ToApiResponse(x => x.Card, "Error creating item card");
    }
}