using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Campaign.DeleteCampaign;

public class DeleteCampaignCommandHandler : IRequestHandler<DeleteCampaignCommand, ApiResponse<Unit>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public DeleteCampaignCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<Unit>> Handle(DeleteCampaignCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.DeleteCampaign(request.CampaignId, request.Token!);
        return result.ToApiResponse(_ => Unit.Value, "Error deleting campaign");
    }
}