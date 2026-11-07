using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Discussion.CreateCampaignThread;

public class CreateCampaignThreadCommandHandler : IRequestHandler<CreateCampaignThreadCommand, ApiResponse<ThreadData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public CreateCampaignThreadCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<ThreadData>> Handle(CreateCampaignThreadCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.CreateThread(
            request.CampaignId, null, request.Title, request.Visibility, request.Token);
        return result.ToApiResponse(x => x.Thread, "Error creating thread");
    }
}