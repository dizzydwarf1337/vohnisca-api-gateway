using Application.Core.Requests;
using Application.Core.Responses;

namespace Application.Interfaces.RpcClients;

public interface ICampaignRpcClient
{
    Task<RpcResult<CampaignResponse>> CreateCampaign(string title, string? description, string token);
    Task<RpcResult<CampaignResponse>> GetCampaign(string campaignId, string token);
    Task<RpcResult<CampaignResponse>> UpdateCampaign(string campaignId, string title, string? description, string token, string? status = null);
    Task<RpcResult<DefaultRpcResponse>> DeleteCampaign(string campaignId, string token);
    Task<RpcResult<PaginationResponse<CampaignData>>> ListMyCampaigns(PaginationSpecification pagination, SortingSpecification sorting, IFilterSpecification filters, string token);
    Task<RpcResult<DefaultRpcResponse>> AddMember(string campaignId, string targetUserId, string role, string token);
    Task<RpcResult<DefaultRpcResponse>> RemoveMember(string campaignId, string targetUserId, string token);
    Task<RpcResult<DefaultRpcResponse>> UpdateMemberRole(string campaignId, string targetUserId, string role, string token);
    Task<RpcResult<MembersResponse>> ListMembers(string campaignId, string token);

    Task<RpcResult<ChapterResponse>> CreateChapter(string campaignId, string? parentId, string title, string? content, string token);
    Task<RpcResult<ChapterResponse>> GetChapter(string chapterId, string token);
    Task<RpcResult<ChapterResponse>> UpdateChapter(string chapterId, string title, string? content, string token);
    Task<RpcResult<DefaultRpcResponse>> DeleteChapter(string chapterId, string token);
    Task<RpcResult<DefaultRpcResponse>> MoveChapter(string chapterId, string? newParentId, string token);
    Task<RpcResult<DefaultRpcResponse>> ReorderChapters(string campaignId, string? parentId, List<string> orderedIds, string token);
    Task<RpcResult<ChapterResponse>> SetChapterVisibility(string chapterId, bool isVisibleToAll, string token);
    Task<RpcResult<DefaultRpcResponse>> GrantChapterAccess(string chapterId, string targetUserId, string token);
    Task<RpcResult<DefaultRpcResponse>> RevokeChapterAccess(string chapterId, string targetUserId, string token);
    Task<RpcResult<DefaultRpcResponse>> SetCurrentChapter(string campaignId, string chapterId, string token);
    Task<RpcResult<ChaptersResponse>> ListCampaignChapters(string campaignId, string token);

    Task<RpcResult<NoteResponse>> CreateNote(string chapterId, string title, string? content, string token);
    Task<RpcResult<NoteResponse>> GetNote(string noteId, string token);
    Task<RpcResult<NoteResponse>> UpdateNote(string noteId, string title, string? content, string token);
    Task<RpcResult<DefaultRpcResponse>> DeleteNote(string noteId, string token);
    Task<RpcResult<NotesResponse>> ListChapterNotes(string chapterId, string token);
    Task<RpcResult<DefaultRpcResponse>> ReorderNotes(string chapterId, List<string> orderedIds, string token);
    Task<RpcResult<NoteResponse>> SetNoteVisibility(string noteId, bool isPublic, string token);
    Task<RpcResult<DefaultRpcResponse>> GrantNoteAccess(string noteId, string targetUserId, string token);
    Task<RpcResult<DefaultRpcResponse>> RevokeNoteAccess(string noteId, string targetUserId, string token);
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