using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Scene.DeleteSceneCard;

public class DeleteSceneCardCommandHandler : IRequestHandler<DeleteSceneCardCommand, ApiResponse<Unit>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public DeleteSceneCardCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<Unit>> Handle(DeleteSceneCardCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.DeleteSceneCard(request.CardId, request.Token);
        return result.ToApiResponse(_ => Unit.Value, "Error deleting scene card");
    }
}