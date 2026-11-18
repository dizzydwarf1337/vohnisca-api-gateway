using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Card.ReturnItemCardToStash;

public class ReturnItemCardToStashCommandHandler : IRequestHandler<ReturnItemCardToStashCommand, ApiResponse<CampaignCardData>>
{
    // The character service's word for the viewer who owns a character (ViewerAccess, camelCase).
    private const string OwnerAccess = "owner";

    private readonly ICampaignRpcClient _campaign;
    private readonly ICharacterRpcClient _characters;

    public ReturnItemCardToStashCommandHandler(ICampaignRpcClient campaign, ICharacterRpcClient characters)
    {
        _campaign = campaign;
        _characters = characters;
    }

    public async Task<ApiResponse<CampaignCardData>> Handle(ReturnItemCardToStashCommand request, CancellationToken cancellationToken)
    {
        var card = await _campaign.GetCampaignCard(request.CardId, request.Token!);
        if (!card.IsSuccess || card.Data is null)
            return ApiResponse<CampaignCardData>.Failure(card.Error ?? "Card not found", 404);
        var holder = card.Data.Card.Meta is { } meta && meta.TryGetProperty("holderId", out var h) && Guid.TryParse(h.GetString(), out var id) ? id : (Guid?)null;
        if (holder is null)
            return ApiResponse<CampaignCardData>.Failure("The item is not held by a character", 422);

        if (!await MayReturn(holder.Value, card.Data.Card.CampaignId, request))
            return ApiResponse<CampaignCardData>.Failure("Only the holder's player or the campaign's master returns it", 403);

        var result = await _campaign.ReturnItemToStash(request.CardId, request.Token!);
        return result.ToApiResponse(x => x.Card, "Error returning the item to the stash");
    }

    // The holder's player, or the campaign's master or co-master.
    private async Task<bool> MayReturn(Guid holder, string campaignId, ReturnItemCardToStashCommand request)
    {
        var character = await _characters.GetCharacterById(holder, request.Token!);
        if (character.IsSuccess && string.Equals(character.Data?.Access, OwnerAccess, StringComparison.OrdinalIgnoreCase))
            return true;
        if (!Guid.TryParse(campaignId, out var campaign) || request.UserId is not { } me) return false;
        var members = await _campaign.ListMembers(campaign, request.Token!);
        return members.IsSuccess && members.Data!.Members.Any(m => m.UserId == me.ToString()
            && m.Role is "master" or "co_master");
    }
}
