using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Card.PickItemCard;

public class PickItemCardCommandHandler : IRequestHandler<PickItemCardCommand, ApiResponse<CampaignCardData>>
{
    // The character service names the viewer's relation to a character with these words (ViewerAccess,
    // camelCase on the wire): only the owner may pick for it.
    private const string OwnerAccess = "owner";

    private readonly ICampaignRpcClient _campaignRpcClient;
    private readonly ICharacterRpcClient _characterRpcClient;

    public PickItemCardCommandHandler(ICampaignRpcClient campaignRpcClient, ICharacterRpcClient characterRpcClient)
    {
        _campaignRpcClient = campaignRpcClient;
        _characterRpcClient = characterRpcClient;
    }

    public async Task<ApiResponse<CampaignCardData>> Handle(PickItemCardCommand request, CancellationToken cancellationToken)
    {
        var character = await _characterRpcClient.GetCharacterById(request.CharacterId, request.Token);
        if (!character.IsSuccess || character.Data is null)
            return ApiResponse<CampaignCardData>.Failure(character.Error ?? "Character not found", 404);

        if (!string.Equals(character.Data.Access, OwnerAccess, StringComparison.OrdinalIgnoreCase))
            return ApiResponse<CampaignCardData>.Failure("The character belongs to another user", 403);

        var result = await _campaignRpcClient.PickItemCard(request.CardId, request.CharacterId, request.Token);
        return result.ToApiResponse(x => x.Card, "Error picking item card");
    }
}
