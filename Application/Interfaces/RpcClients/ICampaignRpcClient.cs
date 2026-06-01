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

    Task<RpcResult<ChapterResponse>> CreateChapter(Guid campaignId, Guid? parentId, string title, string? content, string token);
    Task<RpcResult<ChapterResponse>> GetChapter(Guid chapterId, string token);
    Task<RpcResult<ChapterResponse>> UpdateChapter(Guid chapterId, string title, string? content, string token);
    Task<RpcResult<DefaultRpcResponse>> DeleteChapter(Guid chapterId, string token);
    Task<RpcResult<DefaultRpcResponse>> MoveChapter(Guid chapterId, Guid? newParentId, string token);
    Task<RpcResult<DefaultRpcResponse>> ReorderChapters(Guid campaignId, Guid? parentId, List<string> orderedIds, string token);
    Task<RpcResult<ChapterResponse>> SetChapterVisibility(Guid chapterId, bool isVisibleToAll, string token);
    Task<RpcResult<DefaultRpcResponse>> GrantChapterAccess(Guid chapterId, Guid[] targetUserIds, string token);
    Task<RpcResult<DefaultRpcResponse>> RevokeChapterAccess(Guid chapterId, Guid[] targetUserIds, string token);
    Task<RpcResult<DefaultRpcResponse>> SetCurrentChapter(Guid campaignId, Guid chapterId, string token);
    Task<RpcResult<ChaptersResponse>> ListCampaignChapters(Guid campaignId, string token);

    Task<RpcResult<NoteResponse>> CreateNote(Guid chapterId, string title, string? content, string token);
    Task<RpcResult<NoteResponse>> GetNote(Guid noteId, string token);
    Task<RpcResult<NoteResponse>> UpdateNote(Guid noteId, string title, string? content, string token);
    Task<RpcResult<DefaultRpcResponse>> DeleteNote(Guid noteId, string token);
    Task<RpcResult<NotesResponse>> ListChapterNotes(Guid chapterId, string token);
    Task<RpcResult<DefaultRpcResponse>> ReorderNotes(Guid chapterId, List<string> orderedIds, string token);
    Task<RpcResult<NoteResponse>> SetNoteVisibility(Guid noteId, bool isPublic, string token);
    Task<RpcResult<DefaultRpcResponse>> GrantNoteAccess(Guid noteId, Guid targetUserId, string token);
    Task<RpcResult<DefaultRpcResponse>> RevokeNoteAccess(Guid noteId, Guid targetUserId, string token);
}

public record CampaignResponse(CampaignData Campaign);
public record CampaignsResponse(List<CampaignData> Campaigns);
public record MembersResponse(List<MemberData> Members);
public record ChapterResponse(ChapterData Chapter);
public record ChaptersResponse(List<ChapterData> Chapters);
public record NoteResponse(NoteData Note);
public record NotesResponse(List<NoteData> Notes);

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
    int Order,
    bool IsVisibleToAll,
    bool IsCurrent,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    List<ChapterData>? Children = null,
    List<NoteData>? Notes = null,
    List<ChapterAccessUserData>? AccessUsers = null);

public record ChapterAccessUserData(string UserId, string? UserName);

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