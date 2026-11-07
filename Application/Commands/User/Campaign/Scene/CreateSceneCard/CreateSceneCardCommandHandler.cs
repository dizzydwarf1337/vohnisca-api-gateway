using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Scene.CreateSceneCard;

public class CreateSceneCardCommandHandler : IRequestHandler<CreateSceneCardCommand, ApiResponse<CampaignCardData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public CreateSceneCardCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<CampaignCardData>> Handle(CreateSceneCardCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.CreateSceneCard(
            request.CampaignId, request.ChapterId, request.SceneType, request.MapId, request.LevelId,
            request.Title, request.Content, request.ContentFormat, request.Token);
        return result.ToApiResponse(x => x.Card, "Error creating scene card");
    }
}