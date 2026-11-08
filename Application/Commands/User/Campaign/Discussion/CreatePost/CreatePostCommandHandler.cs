using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Discussion.CreatePost;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, ApiResponse<PostData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public CreatePostCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<PostData>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.PostReply(
            request.ThreadId, request.Body, request.ReplyToId, request.BodyFormat, request.Token);
        return result.ToApiResponse(x => x.Post, "Error posting reply");
    }
}