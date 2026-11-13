using System.Text.Json;
using Application.Core.Requests;
using Application.Core.Responses;
using Application.Interfaces.RpcClients;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.RpcClients;

public class CampaignRpcClient : LaravelRpcClient, ICampaignRpcClient
{
    public CampaignRpcClient(IConfiguration configuration)
        : base(configuration["RpcServices:CampaignService"] ?? throw new Exception("CampaignService URI not set")) { }

    private async Task<RpcResult<T>> Send<T>(string method, Dictionary<string, object>? parameters, string token)
    {
        var result = await SendRpcRequest<T>(method, parameters, token: token);
        if (!result.IsSuccess)
            return RpcResult<T>.Failure(result.Error, ToHttpStatus(result.StatusCode));
        return result;
    }

    private static int ToHttpStatus(int rpcCode) => rpcCode switch
    {
        -32001 => 409,
        -32002 => 403,
        -32003 => 404,
        -32006 => 404,
        -32602 => 422,
        -32601 => 404,
        _ => 500
    };

    public Task<RpcResult<CampaignResponse>> CreateCampaign(string title, string? description, string token)
    {
        var p = new Dictionary<string, object> { { "title", title } };
        if (description != null) p["description"] = description;
        return Send<CampaignResponse>("CreateCampaign", p, token);
    }

    public Task<RpcResult<CampaignResponse>> GetCampaign(Guid campaignId, string token)
        => Send<CampaignResponse>("GetCampaign", new() { { "campaignId", campaignId } }, token);

    public Task<RpcResult<CampaignResponse>> UpdateCampaign(Guid campaignId, string title, string? description, string token, string? status = null)
    {
        var p = new Dictionary<string, object> { { "campaignId", campaignId }, { "title", title } };
        if (description != null) p["description"] = description;
        if (status != null) p["status"] = status;
        return Send<CampaignResponse>("UpdateCampaign", p, token);
    }

    public Task<RpcResult<DefaultRpcResponse>> DeleteCampaign(Guid campaignId, string token)
        => Send<DefaultRpcResponse>("DeleteCampaign", new() { { "campaignId", campaignId } }, token);

    public Task<RpcResult<PaginationResponse<CampaignData>>> ListMyCampaigns(PaginationSpecification pagination, SortingSpecification sorting, IFilterSpecification filters, string token)
    {
        var p = new Dictionary<string, object>
        {
            { "page", pagination.Page },
            { "pageSize", pagination.PageSize },
            { "sortDir", sorting.SortDir }
        };
        if (sorting.SortBy != null) p["sortBy"] = sorting.SortBy;
        foreach (var (key, value) in filters.ToParameters())
            p[key] = value;
        return Send<PaginationResponse<CampaignData>>("ListMyCampaigns", p, token);
    }

    public Task<RpcResult<DefaultRpcResponse>> AddMember(Guid campaignId, Guid targetUserId, string role, string token)
        => Send<DefaultRpcResponse>("AddMember", new() { { "campaignId", campaignId }, { "targetUserId", targetUserId }, { "role", role } }, token);

    public Task<RpcResult<DefaultRpcResponse>> RemoveMember(Guid campaignId, Guid targetUserId, string token)
        => Send<DefaultRpcResponse>("RemoveMember", new() { { "campaignId", campaignId }, { "targetUserId", targetUserId } }, token);

    public Task<RpcResult<DefaultRpcResponse>> UpdateMemberRole(Guid campaignId, Guid targetUserId, string role, string token)
        => Send<DefaultRpcResponse>("UpdateMemberRole", new() { { "campaignId", campaignId }, { "targetUserId", targetUserId }, { "role", role } }, token);

    public Task<RpcResult<MembersResponse>> ListMembers(Guid campaignId, string token)
        => Send<MembersResponse>("ListMembers", new() { { "campaignId", campaignId } }, token);

    public Task<RpcResult<ChapterResponse>> CreateChapter(Guid campaignId, Guid? parentId, string title, string? content, string? contentFormat, string token)
    {
        var p = new Dictionary<string, object> { { "campaignId", campaignId }, { "title", title } };
        if (parentId != null) p["parentId"] = parentId;
        if (content != null) p["content"] = content;
        if (contentFormat != null) p["contentFormat"] = contentFormat;
        return Send<ChapterResponse>("CreateChapter", p, token);
    }

    public Task<RpcResult<ChapterResponse>> GetChapter(Guid chapterId, string token)
        => Send<ChapterResponse>("GetChapter", new() { { "chapterId", chapterId } }, token);

    public Task<RpcResult<ChapterResponse>> UpdateChapter(Guid chapterId, string title, string? content, string? contentFormat, string token)
    {
        var p = new Dictionary<string, object> { { "chapterId", chapterId }, { "title", title } };
        if (content != null) p["content"] = content;
        if (contentFormat != null) p["contentFormat"] = contentFormat;
        return Send<ChapterResponse>("UpdateChapter", p, token);
    }

    public Task<RpcResult<DefaultRpcResponse>> DeleteChapter(Guid chapterId, string token)
        => Send<DefaultRpcResponse>("DeleteChapter", new() { { "chapterId", chapterId } }, token);

    public Task<RpcResult<DefaultRpcResponse>> MoveChapter(Guid chapterId, Guid? newParentId, string token)
    {
        var p = new Dictionary<string, object> { { "chapterId", chapterId } };
        if (newParentId != null) p["newParentId"] = newParentId;
        return Send<DefaultRpcResponse>("MoveChapter", p, token);
    }

    public Task<RpcResult<DefaultRpcResponse>> ReorderChapters(Guid campaignId, Guid? parentId, List<string> orderedIds, string token)
    {
        var p = new Dictionary<string, object> { { "campaignId", campaignId }, { "orderedIds", orderedIds } };
        if (parentId != null) p["parentId"] = parentId;
        return Send<DefaultRpcResponse>("ReorderChapters", p, token);
    }

    public Task<RpcResult<ChapterResponse>> SetChapterVisibility(Guid chapterId, bool isVisibleToAll, string token)
        => Send<ChapterResponse>("SetChapterVisibility", new() { { "chapterId", chapterId }, { "isVisibleToAll", isVisibleToAll } }, token);

    public Task<RpcResult<DefaultRpcResponse>> GrantChapterAccess(Guid chapterId, Guid[] targetUserIds, string token)
        => Send<DefaultRpcResponse>("GrantChapterAccess", new() { { "chapterId", chapterId }, { "targetUserIds", targetUserIds } }, token);

    public Task<RpcResult<DefaultRpcResponse>> RevokeChapterAccess(Guid chapterId, Guid[] targetUserIds, string token)
        => Send<DefaultRpcResponse>("RevokeChapterAccess", new() { { "chapterId", chapterId }, { "targetUserIds", targetUserIds } }, token);

    public Task<RpcResult<DefaultRpcResponse>> SetCurrentChapter(Guid campaignId, Guid chapterId, string token)
        => Send<DefaultRpcResponse>("SetCurrentChapter", new() { { "campaignId", campaignId }, { "chapterId", chapterId } }, token);

    public Task<RpcResult<ChaptersResponse>> ListCampaignChapters(Guid campaignId, string token)
        => Send<ChaptersResponse>("ListCampaignChapters", new() { { "campaignId", campaignId } }, token);

    public Task<RpcResult<NoteResponse>> CreateNote(Guid? chapterId, Guid? campaignId, string title, string? content, string? contentFormat, string token)
    {
        var p = new Dictionary<string, object> { { "title", title } };
        if (chapterId != null) p["chapterId"] = chapterId;
        if (campaignId != null) p["campaignId"] = campaignId;
        if (content != null) p["content"] = content;
        if (contentFormat != null) p["contentFormat"] = contentFormat;
        return Send<NoteResponse>("CreateNote", p, token);
    }

    public Task<RpcResult<NoteResponse>> GetNote(Guid noteId, string token)
        => Send<NoteResponse>("GetNote", new() { { "noteId", noteId } }, token);

    public Task<RpcResult<NoteResponse>> UpdateNote(Guid noteId, string title, string? content, string? contentFormat, string token)
    {
        var p = new Dictionary<string, object> { { "noteId", noteId }, { "title", title } };
        if (content != null) p["content"] = content;
        if (contentFormat != null) p["contentFormat"] = contentFormat;
        return Send<NoteResponse>("UpdateNote", p, token);
    }

    public Task<RpcResult<DefaultRpcResponse>> DeleteNote(Guid noteId, string token)
        => Send<DefaultRpcResponse>("DeleteNote", new() { { "noteId", noteId } }, token);

    public Task<RpcResult<NotesResponse>> ListChapterNotes(Guid chapterId, string token)
        => Send<NotesResponse>("ListChapterNotes", new() { { "chapterId", chapterId } }, token);

    public Task<RpcResult<DefaultRpcResponse>> ReorderNotes(Guid chapterId, List<string> orderedIds, string token)
        => Send<DefaultRpcResponse>("ReorderNotes", new() { { "chapterId", chapterId }, { "orderedIds", orderedIds } }, token);

    public Task<RpcResult<NoteResponse>> SetNoteVisibility(Guid noteId, bool isPublic, string token)
        => Send<NoteResponse>("SetNoteVisibility", new() { { "noteId", noteId }, { "isPublic", isPublic } }, token);

    public Task<RpcResult<DefaultRpcResponse>> GrantNoteAccess(Guid noteId, Guid targetUserId, string token)
        => Send<DefaultRpcResponse>("GrantNoteAccess", new() { { "noteId", noteId }, { "targetUserId", targetUserId } }, token);

    public Task<RpcResult<DefaultRpcResponse>> RevokeNoteAccess(Guid noteId, Guid targetUserId, string token)
        => Send<DefaultRpcResponse>("RevokeNoteAccess", new() { { "noteId", noteId }, { "targetUserId", targetUserId } }, token);

    public Task<RpcResult<NoteResponse>> SetNoteColor(Guid noteId, string? backgroundColor, string token)
    {
        var p = new Dictionary<string, object> { { "noteId", noteId } };
        if (backgroundColor != null) p["backgroundColor"] = backgroundColor;
        return Send<NoteResponse>("SetNoteColor", p, token);
    }

    public Task<RpcResult<CardsResponse>> ListCampaignCards(Guid campaignId, string? kind, Guid? chapterId, bool allChapters, int page, int pageSize, string token)
    {
        var p = new Dictionary<string, object>
        {
            { "campaignId", campaignId },
            { "page", page },
            { "pageSize", pageSize },
        };
        if (kind != null) p["kind"] = kind;
        // A chapterId left out asks for every card of the campaign; a chapterId sent as null asks for
        // the campaign's own cards (the ones filed under no chapter).
        if (!allChapters) p["chapterId"] = chapterId!;
        return Send<CardsResponse>("ListCampaignCards", p, token);
    }

    public Task<RpcResult<CardResponse>> GetCampaignCard(Guid cardId, string token)
        => Send<CardResponse>("GetCampaignCard", new() { { "cardId", cardId } }, token);

    public Task<RpcResult<CardResponse>> CreateNpcCard(Guid campaignId, Guid? chapterId, Guid refId, string title, string? content, string? contentFormat, string token)
    {
        var p = new Dictionary<string, object>
        {
            { "campaignId", campaignId },
            { "refId", refId },
            { "title", title },
        };
        if (chapterId != null) p["chapterId"] = chapterId;
        if (content != null) p["content"] = content;
        if (contentFormat != null) p["contentFormat"] = contentFormat;
        return Send<CardResponse>("CreateNpcCard", p, token);
    }

    public Task<RpcResult<CardsResponse>> ListItemCards(Guid campaignId, Guid? chapterId, Guid? containerId, int page, int pageSize, string token)
    {
        var p = new Dictionary<string, object>
        {
            { "campaignId", campaignId },
            { "page", page },
            { "pageSize", pageSize },
        };
        if (chapterId != null) p["chapterId"] = chapterId;
        if (containerId != null) p["containerId"] = containerId;
        return Send<CardsResponse>("ListItemCards", p, token);
    }

    public Task<RpcResult<CardResponse>> CreateItemCard(Guid campaignId, Guid? chapterId, Guid refId, int quantity, Guid? containerId, string? title, string? content, string? contentFormat, string token)
    {
        var p = new Dictionary<string, object>
        {
            { "campaignId", campaignId },
            { "refId", refId },
            { "quantity", quantity },
        };
        if (chapterId != null) p["chapterId"] = chapterId;
        if (containerId != null) p["containerId"] = containerId;
        if (title != null) p["title"] = title;
        if (content != null) p["content"] = content;
        if (contentFormat != null) p["contentFormat"] = contentFormat;
        return Send<CardResponse>("CreateItemCard", p, token);
    }

    // An empty containerId takes the card out of its container: the campaign service reads it as "none".
    public Task<RpcResult<CardResponse>> MoveItemCard(Guid cardId, Guid? containerId, string token)
    {
        var p = new Dictionary<string, object> { { "cardId", cardId } };
        if (containerId != null) p["containerId"] = containerId;
        return Send<CardResponse>("MoveItemCard", p, token);
    }

    public Task<RpcResult<CardResponse>> GiveItemCardToCharacter(Guid cardId, Guid characterId, string token)
        => Send<CardResponse>("GiveItemCardToCharacter", new() { { "cardId", cardId }, { "characterId", characterId } }, token);

    public Task<RpcResult<CardResponse>> SetItemPickable(Guid cardId, Guid[] userIds, string token)
        => Send<CardResponse>("SetItemPickable", new() { { "cardId", cardId }, { "userIds", userIds } }, token);

    public Task<RpcResult<CardResponse>> PickItemCard(Guid cardId, Guid characterId, string token)
        => Send<CardResponse>("PickItemCard", new() { { "cardId", cardId }, { "characterId", characterId } }, token);

    // The campaign service compares the period by date (whereDate), so the dates go as yyyy-MM-dd.
    public Task<RpcResult<HistoryResponse>> ListCampaignHistory(Guid campaignId, string? kind, Guid? actorId, DateOnly? from, DateOnly? to, int page, int pageSize, string token)
    {
        var p = new Dictionary<string, object>
        {
            { "campaignId", campaignId },
            { "page", page },
            { "pageSize", pageSize },
        };
        if (kind != null) p["kind"] = kind;
        if (actorId != null) p["actorId"] = actorId;
        if (from != null) p["from"] = from.Value.ToString("yyyy-MM-dd");
        if (to != null) p["to"] = to.Value.ToString("yyyy-MM-dd");
        return Send<HistoryResponse>("ListCampaignHistory", p, token);
    }

    public Task<RpcResult<StashesResponse>> ListStashes(Guid campaignId, string token)
        => Send<StashesResponse>("ListStashes", new() { { "campaignId", campaignId } }, token);

    public Task<RpcResult<StashResponse>> CreateStashCard(Guid campaignId, Guid? chapterId, string title, string? content, string? contentFormat, string token)
    {
        var p = new Dictionary<string, object> { { "campaignId", campaignId }, { "title", title } };
        if (chapterId != null) p["chapterId"] = chapterId;
        if (content != null) p["content"] = content;
        if (contentFormat != null) p["contentFormat"] = contentFormat;
        return Send<StashResponse>("CreateStashCard", p, token);
    }

    public Task<RpcResult<StashResponse>> GetStash(Guid cardId, string token)
        => Send<StashResponse>("GetStash", new() { { "cardId", cardId } }, token);

    public Task<RpcResult<ItemRequestResponse>> RequestItemTake(Guid cardId, Guid characterId, string token)
        => Send<ItemRequestResponse>("RequestItemTake", new() { { "cardId", cardId }, { "characterId", characterId } }, token);

    public Task<RpcResult<ItemRequestResponse>> ApproveItemTake(Guid requestId, string token)
        => Send<ItemRequestResponse>("ApproveItemTake", new() { { "requestId", requestId } }, token);

    public Task<RpcResult<ItemRequestResponse>> RejectItemTake(Guid requestId, string token)
        => Send<ItemRequestResponse>("RejectItemTake", new() { { "requestId", requestId } }, token);

    // Only the denominations the caller named go out: the campaign service treats an absent one as zero.
    public Task<RpcResult<StashResponse>> AddStashCoins(Guid cardId, Dictionary<string, int> coins, string token)
        => Send<StashResponse>("AddStashCoins", new() { { "cardId", cardId }, { "coins", coins } }, token);

    public Task<RpcResult<StashResponse>> SpendStashCoins(Guid cardId, Dictionary<string, int> coins, string token)
        => Send<StashResponse>("SpendStashCoins", new() { { "cardId", cardId }, { "coins", coins } }, token);

    public Task<RpcResult<StashResponse>> GiveStashCoinsToCharacter(Guid cardId, Guid characterId, Dictionary<string, int> coins, string token)
        => Send<StashResponse>("GiveStashCoinsToCharacter", new()
        {
            { "cardId", cardId },
            { "characterId", characterId },
            { "coins", coins },
        }, token);

    public Task<RpcResult<CardResponse>> CreateShopCard(Guid campaignId, Guid? chapterId, string title, string? content, string? contentFormat, string token)
    {
        var p = new Dictionary<string, object> { { "campaignId", campaignId }, { "title", title } };
        if (chapterId != null) p["chapterId"] = chapterId;
        if (content != null) p["content"] = content;
        if (contentFormat != null) p["contentFormat"] = contentFormat;
        return Send<CardResponse>("CreateShopCard", p, token);
    }

    public Task<RpcResult<CardResponse>> UpdateShopCard(Guid cardId, string? title, string? content, string? contentFormat, JsonElement? meta, string token)
    {
        var p = new Dictionary<string, object> { { "cardId", cardId } };
        if (title != null) p["title"] = title;
        if (content != null) p["content"] = content;
        if (contentFormat != null) p["contentFormat"] = contentFormat;
        if (meta != null) p["meta"] = meta.Value;
        return Send<CardResponse>("UpdateShopCard", p, token);
    }

    public Task<RpcResult<ShopGoodsResponse>> ListShopGoods(Guid cardId, string token)
        => Send<ShopGoodsResponse>("ListShopGoods", new() { { "cardId", cardId } }, token);

    public Task<RpcResult<ShopGoodResponse>> AddShopGood(Guid cardId, Guid refId, int priceCoins, int? sellPriceCoins, int? stock, bool isBuyable, bool isSellable, string token)
    {
        var p = new Dictionary<string, object>
        {
            { "cardId", cardId },
            { "refId", refId },
            { "priceCoins", priceCoins },
            { "isBuyable", isBuyable },
            { "isSellable", isSellable },
        };
        if (sellPriceCoins != null) p["sellPriceCoins"] = sellPriceCoins;
        if (stock != null) p["stock"] = stock;
        return Send<ShopGoodResponse>("AddShopGood", p, token);
    }

    // The campaign service tells an absent key ("leave it as it is") from an explicit null ("no limit") with
    // array_key_exists, so only the keys the caller named go out — stock included, with its null kept.
    public Task<RpcResult<ShopGoodResponse>> UpdateShopGood(Guid goodId, int? priceCoins, int? sellPriceCoins, JsonElement stock, bool? isBuyable, bool? isSellable, int? order, string token)
    {
        var p = new Dictionary<string, object> { { "goodId", goodId } };
        if (priceCoins != null) p["priceCoins"] = priceCoins;
        if (sellPriceCoins != null) p["sellPriceCoins"] = sellPriceCoins;
        if (isBuyable != null) p["isBuyable"] = isBuyable;
        if (isSellable != null) p["isSellable"] = isSellable;
        if (order != null) p["order"] = order;
        if (stock.ValueKind == JsonValueKind.Null) p["stock"] = null!;
        else if (stock.ValueKind == JsonValueKind.Number) p["stock"] = stock.GetInt32();
        return Send<ShopGoodResponse>("UpdateShopGood", p, token);
    }

    public Task<RpcResult<DefaultRpcResponse>> RemoveShopGood(Guid goodId, string token)
        => Send<DefaultRpcResponse>("RemoveShopGood", new() { { "goodId", goodId } }, token);

    public Task<RpcResult<CampaignCharactersResponse>> ListCampaignCharacters(Guid campaignId, string token)
        => Send<CampaignCharactersResponse>("ListCampaignCharacters", new() { { "campaignId", campaignId } }, token);

    public Task<RpcResult<CampaignResponse>> SetHitPointsMode(Guid campaignId, string mode, string token)
        => Send<CampaignResponse>("SetHitPointsMode", new() { { "campaignId", campaignId }, { "mode", mode } }, token);

    // GrantLevelUp, ReleaseCampaignCharacter, AdmitCampaignCharacter: the same shape, the campaign service decides.
    public Task<RpcResult<CampaignCharacterResponse>> CampaignCharacterAction(string method, Guid campaignId, Guid characterId, string token)
        => Send<CampaignCharacterResponse>(method, new() { { "campaignId", campaignId }, { "characterId", characterId } }, token);

    public Task<RpcResult<ShopPurchaseResponse>> BuyFromShop(Guid cardId, Guid goodId, int quantity, Guid characterId, string token)
        => Send<ShopPurchaseResponse>("BuyFromShop", new()
        {
            { "cardId", cardId },
            { "goodId", goodId },
            { "quantity", quantity },
            { "characterId", characterId },
        }, token);

    public Task<RpcResult<ShopPurchaseResponse>> SellToShop(Guid cardId, Guid itemCardId, string token)
        => Send<ShopPurchaseResponse>("SellToShop", new() { { "cardId", cardId }, { "itemCardId", itemCardId } }, token);

    public Task<RpcResult<ShopGoodResponse>> SetShopOffer(Guid goodId, Guid targetUserId, int priceCoins, string token)
        => Send<ShopGoodResponse>("SetShopOffer", new()
        {
            { "goodId", goodId },
            { "targetUserId", targetUserId },
            { "priceCoins", priceCoins },
        }, token);

    public Task<RpcResult<ShopPurchaseResponse>> ApprovePurchase(Guid purchaseId, string token)
        => Send<ShopPurchaseResponse>("ApprovePurchase", new() { { "purchaseId", purchaseId } }, token);

    public Task<RpcResult<CardResponse>> CreateSceneCard(Guid campaignId, Guid? chapterId, string sceneType, Guid? mapId, string? levelId, string title, string? content, string? contentFormat, string token)
    {
        var p = new Dictionary<string, object>
        {
            { "campaignId", campaignId },
            { "sceneType", sceneType },
            { "title", title },
        };
        if (chapterId != null) p["chapterId"] = chapterId;
        if (mapId != null) p["mapId"] = mapId;
        if (levelId != null) p["levelId"] = levelId;
        if (content != null) p["content"] = content;
        if (contentFormat != null) p["contentFormat"] = contentFormat;
        return Send<CardResponse>("CreateSceneCard", p, token);
    }

    public Task<RpcResult<CardResponse>> SetSceneRevealed(Guid cardId, bool isPublic, string token)
        => Send<CardResponse>("SetSceneRevealed", new() { { "cardId", cardId }, { "isPublic", isPublic } }, token);

    // The entries go as camelCase objects: the campaign service reads npcs.*.npcId / items.*.refId by those
    // exact keys, and a record would serialize its properties in PascalCase.
    public Task<RpcResult<CardResponse>> SetSceneComposition(Guid cardId, List<SceneNpcEntry> npcs, List<SceneItemEntry> items, string token)
        => Send<CardResponse>("SetSceneComposition", new()
        {
            { "cardId", cardId },
            { "npcs", npcs.Select(n => new { npcId = n.NpcId, count = n.Count }).ToList() },
            { "items", items.Select(i => new { refId = i.RefId, quantity = i.Quantity }).ToList() },
        }, token);

    // The campaign service has no card delete yet (stage 06 shipped without it): the route exists as the
    // contract asks, and until deleteSceneCard lands there the answer is the service's -32601 → 404.
    public Task<RpcResult<CardResponse>> DeleteSceneCard(Guid cardId, string token)
        => Send<CardResponse>("DeleteSceneCard", new() { { "cardId", cardId } }, token);

    public Task<RpcResult<ThreadsResponse>> ListCampaignThreads(Guid campaignId, Guid? chapterId, int page, int pageSize, string token)
    {
        var p = new Dictionary<string, object>
        {
            { "campaignId", campaignId },
            { "page", page },
            { "pageSize", pageSize },
        };
        if (chapterId != null) p["chapterId"] = chapterId;
        return Send<ThreadsResponse>("ListCampaignThreads", p, token);
    }

    public Task<RpcResult<ThreadViewResponse>> GetThread(Guid threadId, int page, int pageSize, string token)
        => Send<ThreadViewResponse>("GetThread", new()
        {
            { "threadId", threadId },
            { "page", page },
            { "pageSize", pageSize },
        }, token);

    public Task<RpcResult<ThreadResponse>> CreateThread(Guid campaignId, Guid? chapterId, string title, string visibility, string token)
    {
        var p = new Dictionary<string, object> { { "campaignId", campaignId }, { "title", title }, { "visibility", visibility } };
        if (chapterId != null) p["chapterId"] = chapterId;
        return Send<ThreadResponse>("CreateThread", p, token);
    }

    public Task<RpcResult<PostResponse>> PostReply(Guid threadId, string body, Guid? replyToId, string? bodyFormat, string token)
    {
        var p = new Dictionary<string, object> { { "threadId", threadId }, { "body", body } };
        if (replyToId != null) p["replyToId"] = replyToId;
        if (bodyFormat != null) p["bodyFormat"] = bodyFormat;
        return Send<PostResponse>("PostReply", p, token);
    }

    public Task<RpcResult<PostResponse>> EditPost(Guid postId, string body, string? bodyFormat, string token)
    {
        var p = new Dictionary<string, object> { { "postId", postId }, { "body", body } };
        if (bodyFormat != null) p["bodyFormat"] = bodyFormat;
        return Send<PostResponse>("EditPost", p, token);
    }

    public Task<RpcResult<PostResponse>> DeletePost(Guid postId, string token)
        => Send<PostResponse>("DeletePost", new() { { "postId", postId } }, token);

    public Task<RpcResult<ThreadResponse>> SetThreadPinned(Guid threadId, bool isPinned, string token)
        => Send<ThreadResponse>("SetThreadPinned", new() { { "threadId", threadId }, { "isPinned", isPinned } }, token);

    public Task<RpcResult<ThreadResponse>> SetThreadLocked(Guid threadId, bool isLocked, string token)
        => Send<ThreadResponse>("SetThreadLocked", new() { { "threadId", threadId }, { "isLocked", isLocked } }, token);

    public Task<RpcResult<ThreadResponse>> SetThreadHidden(Guid threadId, bool isHidden, string token)
        => Send<ThreadResponse>("SetThreadHidden", new() { { "threadId", threadId }, { "isHidden", isHidden } }, token);

    public Task<RpcResult<ThreadReadResponse>> MarkThreadRead(Guid threadId, string token)
        => Send<ThreadReadResponse>("MarkThreadRead", new() { { "threadId", threadId } }, token);

    public Task<RpcResult<UnreadCountsResponse>> GetUnreadCounts(Guid campaignId, string token)
        => Send<UnreadCountsResponse>("GetUnreadCounts", new() { { "campaignId", campaignId } }, token);

    public Task<RpcResult<CardResponse>> UpdateCampaignCard(Guid cardId, string? title, string? content, string? contentFormat, JsonElement? meta, string? backgroundColor, int? order, string token)
    {
        var p = new Dictionary<string, object> { { "cardId", cardId } };
        if (title != null) p["title"] = title;
        if (content != null) p["content"] = content;
        if (contentFormat != null) p["contentFormat"] = contentFormat;
        if (meta != null) p["meta"] = meta.Value;
        if (backgroundColor != null) p["backgroundColor"] = backgroundColor;
        if (order != null) p["order"] = order;
        return Send<CardResponse>("UpdateCampaignCard", p, token);
    }

    public Task<RpcResult<CardResponse>> SetCampaignCardVisibility(Guid cardId, bool isPublic, string token)
        => Send<CardResponse>("SetCampaignCardVisibility", new() { { "cardId", cardId }, { "isPublic", isPublic } }, token);

    // A missing chapterId reads as null on the service side, which takes the card back to the campaign itself.
    public Task<RpcResult<CardResponse>> SetCampaignCardChapter(Guid cardId, Guid? chapterId, string token)
    {
        var p = new Dictionary<string, object> { { "cardId", cardId } };
        if (chapterId != null) p["chapterId"] = chapterId;
        return Send<CardResponse>("SetCampaignCardChapter", p, token);
    }

    public Task<RpcResult<DefaultRpcResponse>> GrantCampaignCardAccess(Guid cardId, Guid targetUserId, string token)
        => Send<DefaultRpcResponse>("GrantCampaignCardAccess", new() { { "cardId", cardId }, { "targetUserId", targetUserId } }, token);

    public Task<RpcResult<DefaultRpcResponse>> RevokeCampaignCardAccess(Guid cardId, Guid targetUserId, string token)
        => Send<DefaultRpcResponse>("RevokeCampaignCardAccess", new() { { "cardId", cardId }, { "targetUserId", targetUserId } }, token);

    public Task<RpcResult<DefaultRpcResponse>> ReorderCampaignCards(Guid campaignId, Guid? chapterId, List<string> orderedIds, string token)
    {
        var p = new Dictionary<string, object> { { "campaignId", campaignId }, { "orderedIds", orderedIds } };
        if (chapterId != null) p["chapterId"] = chapterId;
        return Send<DefaultRpcResponse>("ReorderCampaignCards", p, token);
    }

    public Task<RpcResult<CampaignImageResponse>> UploadCampaignImage(Guid campaignId, string mimeType, string data, string token)
        => Send<CampaignImageResponse>("UploadCampaignImage", new()
        {
            { "campaignId", campaignId },
            { "mimeType", mimeType },
            { "data", data },
        }, token);

    public Task<RpcResult<CampaignImageContentResponse>> GetCampaignImage(Guid imageId, string token)
        => Send<CampaignImageContentResponse>("GetCampaignImage", new() { { "imageId", imageId } }, token);
}