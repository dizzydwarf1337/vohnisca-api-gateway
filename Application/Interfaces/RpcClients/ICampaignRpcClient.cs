using System.Text.Json;
using Application.Core.Requests;
using Application.Core.Responses;

namespace Application.Interfaces.RpcClients;

public interface ICampaignRpcClient
{
    Task<RpcResult<CampaignResponse>> CreateCampaign(string title, string? description, string token);
    Task<RpcResult<CampaignResponse>> GetCampaign(Guid campaignId, string token);
    Task<RpcResult<CampaignResponse>> UpdateCampaign(Guid campaignId, string title, string? description, string token, string? status = null);
    Task<RpcResult<DefaultRpcResponse>> DeleteCampaign(Guid campaignId, string token);
    Task<RpcResult<PaginationResponse<CampaignData>>> ListMyCampaigns(PaginationSpecification pagination, SortingSpecification sorting, IFilterSpecification filters, string token);
    Task<RpcResult<DefaultRpcResponse>> AddMember(Guid campaignId, Guid targetUserId, string role, string token);
    Task<RpcResult<DefaultRpcResponse>> RemoveMember(Guid campaignId, Guid targetUserId, string token);
    Task<RpcResult<DefaultRpcResponse>> UpdateMemberRole(Guid campaignId, Guid targetUserId, string role, string token);
    Task<RpcResult<MembersResponse>> ListMembers(Guid campaignId, string token);

    Task<RpcResult<ChapterResponse>> CreateChapter(Guid campaignId, Guid? parentId, string title, string? content, string? contentFormat, string token);
    Task<RpcResult<ChapterResponse>> GetChapter(Guid chapterId, string token);
    Task<RpcResult<ChapterResponse>> UpdateChapter(Guid chapterId, string title, string? content, string? contentFormat, string token);
    Task<RpcResult<DefaultRpcResponse>> DeleteChapter(Guid chapterId, string token);
    Task<RpcResult<DefaultRpcResponse>> MoveChapter(Guid chapterId, Guid? newParentId, string token);
    Task<RpcResult<DefaultRpcResponse>> ReorderChapters(Guid campaignId, Guid? parentId, List<string> orderedIds, string token);
    Task<RpcResult<ChapterResponse>> SetChapterVisibility(Guid chapterId, bool isVisibleToAll, string token);
    Task<RpcResult<DefaultRpcResponse>> GrantChapterAccess(Guid chapterId, Guid[] targetUserIds, string token);
    Task<RpcResult<DefaultRpcResponse>> RevokeChapterAccess(Guid chapterId, Guid[] targetUserIds, string token);
    Task<RpcResult<DefaultRpcResponse>> SetCurrentChapter(Guid campaignId, Guid chapterId, string token);
    Task<RpcResult<ChaptersResponse>> ListCampaignChapters(Guid campaignId, string token);

    Task<RpcResult<NoteResponse>> CreateNote(Guid? chapterId, Guid? campaignId, string title, string? content, string? contentFormat, string token);
    Task<RpcResult<NoteResponse>> GetNote(Guid noteId, string token);
    Task<RpcResult<NoteResponse>> UpdateNote(Guid noteId, string title, string? content, string? contentFormat, string token);
    Task<RpcResult<DefaultRpcResponse>> DeleteNote(Guid noteId, string token);
    Task<RpcResult<NotesResponse>> ListChapterNotes(Guid chapterId, string token);
    Task<RpcResult<DefaultRpcResponse>> ReorderNotes(Guid chapterId, List<string> orderedIds, string token);
    Task<RpcResult<NoteResponse>> SetNoteVisibility(Guid noteId, bool isPublic, string token);
    Task<RpcResult<DefaultRpcResponse>> GrantNoteAccess(Guid noteId, Guid targetUserId, string token);
    Task<RpcResult<DefaultRpcResponse>> RevokeNoteAccess(Guid noteId, Guid targetUserId, string token);
    Task<RpcResult<NoteResponse>> SetNoteColor(Guid noteId, string? backgroundColor, string token);

    Task<RpcResult<CardsResponse>> ListCampaignCards(Guid campaignId, string? kind, Guid? chapterId, bool allChapters, int page, int pageSize, string token);
    Task<RpcResult<CardResponse>> GetCampaignCard(Guid cardId, string token);
    Task<RpcResult<CardResponse>> CreateNpcCard(Guid campaignId, Guid? chapterId, Guid refId, string title, string? content, string? contentFormat, string token);
    Task<RpcResult<CardsResponse>> ListItemCards(Guid campaignId, Guid? chapterId, Guid? containerId, int page, int pageSize, string token);
    Task<RpcResult<CardResponse>> CreateItemCard(Guid campaignId, Guid? chapterId, Guid refId, int quantity, Guid? containerId, string? title, string? content, string? contentFormat, string token);
    Task<RpcResult<CardResponse>> MoveItemCard(Guid cardId, Guid? containerId, string token);
    Task<RpcResult<CardResponse>> GiveItemCardToCharacter(Guid cardId, Guid characterId, string token);
    Task<RpcResult<CardResponse>> SetItemPickable(Guid cardId, Guid[] userIds, string token);
    Task<RpcResult<CardResponse>> PickItemCard(Guid cardId, Guid characterId, string token);
    Task<RpcResult<HistoryResponse>> ListCampaignHistory(Guid campaignId, string? kind, Guid? actorId, DateOnly? from, DateOnly? to, int page, int pageSize, string token);

    Task<RpcResult<StashesResponse>> ListStashes(Guid campaignId, string token);
    Task<RpcResult<StashResponse>> CreateStashCard(Guid campaignId, Guid? chapterId, string title, string? content, string? contentFormat, string token);
    Task<RpcResult<StashResponse>> GetStash(Guid cardId, string token);
    Task<RpcResult<ItemRequestResponse>> RequestItemTake(Guid cardId, Guid characterId, string token);
    Task<RpcResult<ItemRequestResponse>> ApproveItemTake(Guid requestId, string token);
    Task<RpcResult<ItemRequestResponse>> RejectItemTake(Guid requestId, string token);
    Task<RpcResult<StashResponse>> AddStashCoins(Guid cardId, Dictionary<string, int> coins, string token);
    Task<RpcResult<StashResponse>> SpendStashCoins(Guid cardId, Dictionary<string, int> coins, string token);
    Task<RpcResult<StashResponse>> GiveStashCoinsToCharacter(Guid cardId, Guid characterId, Dictionary<string, int> coins, string token);

    Task<RpcResult<CardResponse>> CreateShopCard(Guid campaignId, Guid? chapterId, string title, string? content, string? contentFormat, string token);
    Task<RpcResult<CardResponse>> UpdateShopCard(Guid cardId, string? title, string? content, string? contentFormat, JsonElement? meta, string token);
    Task<RpcResult<ShopGoodsResponse>> ListShopGoods(Guid cardId, string token);
    Task<RpcResult<ShopGoodResponse>> AddShopGood(Guid cardId, Guid refId, int priceCoins, int? sellPriceCoins, int? stock, bool isBuyable, bool isSellable, string token);
    Task<RpcResult<ShopGoodResponse>> UpdateShopGood(Guid goodId, int? priceCoins, int? sellPriceCoins, JsonElement stock, bool? isBuyable, bool? isSellable, int? order, string token);
    Task<RpcResult<DefaultRpcResponse>> RemoveShopGood(Guid goodId, string token);
    Task<RpcResult<ShopPurchaseResponse>> BuyFromShop(Guid cardId, Guid goodId, int quantity, Guid characterId, string token);
    Task<RpcResult<ShopPurchaseResponse>> SellToShop(Guid cardId, Guid itemCardId, string token);
    Task<RpcResult<ShopGoodResponse>> SetShopOffer(Guid goodId, Guid targetUserId, int priceCoins, string token);
    Task<RpcResult<ShopPurchaseResponse>> ApprovePurchase(Guid purchaseId, string token);

    Task<RpcResult<CardResponse>> CreateSceneCard(Guid campaignId, Guid? chapterId, string sceneType, Guid? mapId, string? levelId, string title, string? content, string? contentFormat, string token);
    Task<RpcResult<CardResponse>> SetSceneRevealed(Guid cardId, bool isPublic, string token);
    Task<RpcResult<CardResponse>> SetSceneComposition(Guid cardId, List<SceneNpcEntry> npcs, List<SceneItemEntry> items, string token);
    Task<RpcResult<CardResponse>> DeleteSceneCard(Guid cardId, string token);

    Task<RpcResult<ThreadsResponse>> ListCampaignThreads(Guid campaignId, Guid? chapterId, int page, int pageSize, string token);
    Task<RpcResult<ThreadViewResponse>> GetThread(Guid threadId, int page, int pageSize, string token);
    Task<RpcResult<ThreadResponse>> CreateThread(Guid campaignId, Guid? chapterId, string title, string visibility, string token);
    Task<RpcResult<PostResponse>> PostReply(Guid threadId, string body, Guid? replyToId, string? bodyFormat, string token);
    Task<RpcResult<PostResponse>> EditPost(Guid postId, string body, string? bodyFormat, string token);
    Task<RpcResult<PostResponse>> DeletePost(Guid postId, string token);
    Task<RpcResult<ThreadResponse>> SetThreadPinned(Guid threadId, bool isPinned, string token);
    Task<RpcResult<ThreadResponse>> SetThreadLocked(Guid threadId, bool isLocked, string token);
    Task<RpcResult<ThreadResponse>> SetThreadHidden(Guid threadId, bool isHidden, string token);
    Task<RpcResult<ThreadReadResponse>> MarkThreadRead(Guid threadId, string token);
    Task<RpcResult<UnreadCountsResponse>> GetUnreadCounts(Guid campaignId, string token);
    Task<RpcResult<CardResponse>> UpdateCampaignCard(Guid cardId, string? title, string? content, string? contentFormat, JsonElement? meta, string? backgroundColor, int? order, string token);
    Task<RpcResult<CardResponse>> SetCampaignCardVisibility(Guid cardId, bool isPublic, string token);
    Task<RpcResult<DefaultRpcResponse>> GrantCampaignCardAccess(Guid cardId, Guid targetUserId, string token);
    Task<RpcResult<DefaultRpcResponse>> RevokeCampaignCardAccess(Guid cardId, Guid targetUserId, string token);
    Task<RpcResult<DefaultRpcResponse>> ReorderCampaignCards(Guid campaignId, Guid? chapterId, List<string> orderedIds, string token);

    Task<RpcResult<CampaignImageResponse>> UploadCampaignImage(Guid campaignId, string mimeType, string data, string token);
    Task<RpcResult<CampaignImageContentResponse>> GetCampaignImage(Guid imageId, string token);
}

public record CampaignResponse(CampaignData Campaign);
public record CampaignsResponse(List<CampaignData> Campaigns);
public record MembersResponse(List<MemberData> Members);
public record ChapterResponse(ChapterData Chapter);
public record ChaptersResponse(List<ChapterData> Chapters);
public record NoteResponse(NoteData Note);
public record NotesResponse(List<NoteData> Notes);
public record CardResponse(CampaignCardData Card);
// The campaign service answers a list with its paginated payload ({items, page, pageSize, hasNextPage,
// pagesCount}); the gateway hands the frontend the flat array it reads (Card list, 00).
public record CardsResponse(List<CampaignCardData> Items);
public record HistoryResponse(List<HistoryEntryData> Items);
public record StashResponse(StashData Stash);
public record StashesResponse(List<StashData> Stashes);
public record ItemRequestResponse(ItemRequestData ItemRequest);
public record ShopGoodResponse(ShopGoodData ShopGood);
public record ShopGoodsResponse(List<ShopGoodData> Goods);
public record ShopPurchaseResponse(ShopPurchaseData ShopPurchase);
// A scene's composition: how many of an NPC and how many of a workshop item the encounter holds.
public record SceneNpcEntry(Guid NpcId, int Count);
public record SceneItemEntry(Guid RefId, int Quantity);
public record ThreadResponse(ThreadData Thread);
public record ThreadsResponse(List<ThreadData> Items);
public record PostResponse(PostData Post);
public record ThreadReadResponse(string ThreadId, DateTime? LastReadAt);
public record UnreadCountsResponse(int Total, int Campaign, List<ChapterUnreadData> Chapters);
public record ChapterUnreadData(string ChapterId, int Unread);
// The thread screen in one answer: the topic and a window of its messages (oldest first among themselves).
public record ThreadViewResponse(ThreadData Thread, List<PostData> Posts, int Page, int PageSize, bool HasNextPage, int PagesCount);

public record CampaignData(
    string Id,
    string Title,
    string? Description,
    string CreatedBy,
    string Status,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    List<MemberData>? Members = null);

public record MemberData(string UserId, string Role, string? Username = null);

public record ChapterData(
    string Id,
    string CampaignId,
    string? ParentId,
    string Title,
    string? Content,
    string? ContentFormat,
    int Order,
    bool IsVisibleToAll,
    bool IsCurrent,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    List<ChapterData>? Children = null,
    List<NoteData>? Notes = null,
    List<ChapterAccessUserData>? AccessUsers = null);

public record ChapterAccessUserData(string UserId, string? UserName);

public record CampaignImageResponse(CampaignImageData Image);
public record CampaignImageContentResponse(CampaignImageContentData Image);

public record CampaignImageData(string Id, string CampaignId, string MimeType, DateTime CreatedAt);
public record CampaignImageContentData(string Id, string MimeType, string Data);

public record NoteData(
    string Id,
    string ChapterId,
    string AuthorId,
    string Title,
    string? Content,
    string? ContentFormat,
    bool IsPublic,
    int Order,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    List<ChapterAccessUserData>? AccessUsers = null,
    string? BackgroundColor = null);

// A campaign card: a note with a kind, an optional reference to a workshop entry and kind-specific
// meta. The optional fields trail: AccessUsers arrives only for a loaded relation, and RefData is the
// projection the campaign service builds for this reader (stage 01: an NPC's name, creature type,
// portrait; the stat block for the game master only).
public record CampaignCardData(
    string Id,
    string CampaignId,
    string? ChapterId,
    string? ParentId,
    string Kind,
    string? RefId,
    string? RefName,
    bool RefDeleted,
    JsonElement? Meta,
    string Title,
    string? Content,
    string? ContentFormat,
    bool IsPublic,
    string? BackgroundColor,
    int Order,
    string AuthorId,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    List<ChapterAccessUserData>? AccessUsers = null,
    JsonElement? RefData = null,
    // A tree only: the item cards of a container ride inside it, and the depth is two.
    List<CampaignCardData>? Children = null);

// One line of the campaign journal: what happened, who did it, and between what (fromRef/toRef hold a
// card, a character or the chest; payload carries the numbers — quantity, price, name).
public record HistoryEntryData(
    string Id,
    string CampaignId,
    string Kind,
    string SubjectType,
    string? SubjectId,
    string ActorId,
    string? ActorName,
    string? FromRef,
    string? ToRef,
    JsonElement? Payload,
    DateTime CreatedAt);

// A party stash is a card of its own kind: the cash box (coins), whether taking needs the master's
// approval, and what lies in it. Items arrive as the card tree of 02 (a stash holds containers, a
// container holds items); a treasury answer carries the coins only, so Items stays null there.
public record StashData(
    string Id,
    string CampaignId,
    string? ChapterId,
    string Kind,
    string Title,
    string? Content,
    string? ContentFormat,
    bool IsPublic,
    string? BackgroundColor,
    int Order,
    string AuthorId,
    StashCoinsData Coins,
    bool TakeApproval,
    string? TransferStatus,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    List<CampaignCardData>? Items = null,
    List<ChapterAccessUserData>? AccessUsers = null);

public record StashCoinsData(int Cp, int Sp, int Ep, int Gp, int Pp);

// A request to take something out of a stash (in later stages — a purchase or a sale) and its decision.
public record ItemRequestData(
    string Id,
    string CampaignId,
    string CardId,
    string UserId,
    string? CharacterId,
    string Type,
    string Status,
    string? DecidedBy,
    DateTime? DecidedAt,
    DateTime CreatedAt,
    DateTime UpdatedAt);

// A good of a shop: a workshop type with the price the server decided for this reader (their own offer
// first, the base price otherwise) and how many are left (a null stock means "as many as anybody wants").
public record ShopGoodData(
    string Id,
    string ShopCardId,
    string RefId,
    string? RefName,
    double? RefCost,
    int Price,
    int? OfferPrice,
    int EffectivePrice,
    int SellPrice,
    int? Stock,
    bool IsBuyable,
    bool IsSellable,
    int Order,
    DateTime CreatedAt,
    DateTime UpdatedAt);

// A thread of a chapter or of the campaign itself, with what the list needs (messages, last activity) and,
// for a reader, how much of it is still unread.
public record ThreadData(
    string Id,
    string CampaignId,
    string? ChapterId,
    string Title,
    string CreatedBy,
    string? CreatedByName,
    bool IsPinned,
    bool IsLocked,
    bool IsHidden,
    string Visibility,
    DateTime? LastPostAt,
    int? PostCount,
    int? UnreadCount,
    DateTime CreatedAt,
    DateTime UpdatedAt);

// A message of a thread: plain or rich text (BodyFormat says which) and the moment it was last edited.
// A deleted message keeps its place with no text.
public record PostData(
    string Id,
    string ThreadId,
    string AuthorId,
    string? AuthorName,
    string? Body,
    string? BodyFormat,
    string? ReplyToId,
    bool IsDeleted,
    DateTime? EditedAt,
    DateTime CreatedAt,
    DateTime UpdatedAt);

// One attempt to buy from (or sell to) a shop and where it stands: pending, completed or failed with the
// reason the player sees.
public record ShopPurchaseData(
    string Id,
    string CampaignId,
    string ShopCardId,
    string UserId,
    string CharacterId,
    string RefId,
    string? ItemCardId,
    int Quantity,
    int Price,
    string Type,
    string Status,
    string? Error,
    string? ApprovedBy,
    DateTime? ApprovedAt,
    DateTime? PublishedAt,
    DateTime CreatedAt,
    DateTime UpdatedAt);