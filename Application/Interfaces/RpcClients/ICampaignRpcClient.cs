namespace Application.Interfaces.RpcClients;

public interface ICampaignRpcClient
{
    Task<RpcResult<CampaignResponse>> CreateCampaign(string title, string? description, string userId);
    Task<RpcResult<CampaignResponse>> GetCampaign(string campaignId, string userId);
    Task<RpcResult<CampaignResponse>> UpdateCampaign(string campaignId, string title, string? description, string userId);
    Task<RpcResult<DefaultRpcResponse>> DeleteCampaign(string campaignId, string userId);
    Task<RpcResult<CampaignsResponse>> ListMyCampaigns(string userId);
    Task<RpcResult<DefaultRpcResponse>> AddMember(string campaignId, string targetUserId, string role, string userId);
    Task<RpcResult<DefaultRpcResponse>> RemoveMember(string campaignId, string targetUserId, string userId);
    Task<RpcResult<DefaultRpcResponse>> UpdateMemberRole(string campaignId, string targetUserId, string role, string userId);
    Task<RpcResult<MembersResponse>> ListMembers(string campaignId, string userId);

    Task<RpcResult<ChapterResponse>> CreateChapter(string campaignId, string? parentId, string title, string? content, string userId);
    Task<RpcResult<ChapterResponse>> GetChapter(string chapterId, string userId);
    Task<RpcResult<ChapterResponse>> UpdateChapter(string chapterId, string title, string? content, string userId);
    Task<RpcResult<DefaultRpcResponse>> DeleteChapter(string chapterId, string userId);
    Task<RpcResult<DefaultRpcResponse>> MoveChapter(string chapterId, string? newParentId, string userId);
    Task<RpcResult<DefaultRpcResponse>> ReorderChapters(string campaignId, string? parentId, List<string> orderedIds, string userId);
    Task<RpcResult<ChapterResponse>> SetChapterVisibility(string chapterId, bool isVisibleToAll, string userId);
    Task<RpcResult<DefaultRpcResponse>> GrantChapterAccess(string chapterId, string targetUserId, string userId);
    Task<RpcResult<DefaultRpcResponse>> RevokeChapterAccess(string chapterId, string targetUserId, string userId);

    Task<RpcResult<NoteResponse>> CreateNote(string chapterId, string title, string? content, string userId);
    Task<RpcResult<NoteResponse>> GetNote(string noteId, string userId);
    Task<RpcResult<NoteResponse>> UpdateNote(string noteId, string title, string? content, string userId);
    Task<RpcResult<DefaultRpcResponse>> DeleteNote(string noteId, string userId);
    Task<RpcResult<NotesResponse>> ListChapterNotes(string chapterId, string userId);
    Task<RpcResult<DefaultRpcResponse>> ReorderNotes(string chapterId, List<string> orderedIds, string userId);
    Task<RpcResult<NoteResponse>> SetNoteVisibility(string noteId, bool isPublic, string userId);
    Task<RpcResult<DefaultRpcResponse>> GrantNoteAccess(string noteId, string targetUserId, string userId);
    Task<RpcResult<DefaultRpcResponse>> RevokeNoteAccess(string noteId, string targetUserId, string userId);
}

public record CampaignResponse(CampaignData Campaign);
public record CampaignsResponse(List<CampaignData> Campaigns);
public record MembersResponse(List<MemberData> Members);
public record ChapterResponse(ChapterData Chapter);
public record NoteResponse(NoteData Note);
public record NotesResponse(List<NoteData> Notes);

public record CampaignData(
    string Id,
    string Title,
    string? Description,
    string CreatedBy,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    List<MemberData>? Members = null);

public record MemberData(string UserId, string Role);

public record ChapterData(
    string Id,
    string CampaignId,
    string? ParentId,
    string Title,
    string? Content,
    int Order,
    bool IsVisibleToAll,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    List<ChapterData>? Children = null,
    List<NoteData>? Notes = null);

public record NoteData(
    string Id,
    string ChapterId,
    string AuthorId,
    string Title,
    string? Content,
    bool IsPublic,
    int Order,
    DateTime CreatedAt,
    DateTime UpdatedAt);