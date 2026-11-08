using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Stash.CreateStash;

public class CreateStashCommandHandler : IRequestHandler<CreateStashCommand, ApiResponse<StashData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public CreateStashCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<StashData>> Handle(CreateStashCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.CreateStashCard(
            request.CampaignId, request.ChapterId, request.Title, request.Content, request.ContentFormat, request.Token);
        return result.ToApiResponse(x => x.Stash, "Error creating stash");
    }
}