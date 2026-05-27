using Application.Interfaces.RpcClients;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.RpcClients;

public class CampaignRpcClient : LaravelRpcClient, ICampaignRpcClient
{
    public CampaignRpcClient(IConfiguration configuration)
        : base(configuration["RpcServices:CampaignService"] ?? throw new Exception("CampaignService URI not set")) { }

    private async Task<RpcResult<T>> Send<T>(string method, Dictionary<string, object>? parameters, string userId)
    {
        var result = await SendRpcRequest<T>(method, parameters, userId: userId);
        if (!result.IsSuccess)
            return RpcResult<T>.Failure(result.Error, ToHttpStatus(result.StatusCode));
        return result;
    }

    private static int ToHttpStatus(int rpcCode) => rpcCode switch
    {
        -32001 => 409,
        -32002 => 403,
        -32003 => 404,
        -32602 => 422,
        -32601 => 404,
        _ => 500
    };

    public Task<RpcResult<CampaignResponse>> CreateCampaign(string title, string? description, string userId)
    {
        var p = new Dictionary<string, object> { { "title", title } };
        if (description != null) p["description"] = description;
        return Send<CampaignResponse>("CreateCampaign", p, userId);
    }

    public Task<RpcResult<CampaignResponse>> GetCampaign(string campaignId, string userId)
        => Send<CampaignResponse>("GetCampaign", new() { { "campaignId", campaignId } }, userId);

    public Task<RpcResult<CampaignResponse>> UpdateCampaign(string campaignId, string title, string? description, string userId)
    {
        var p = new Dictionary<string, object> { { "campaignId", campaignId }, { "title", title } };
        if (description != null) p["description"] = description;
        return Send<CampaignResponse>("UpdateCampaign", p, userId);
    }

    public Task<RpcResult<DefaultRpcResponse>> DeleteCampaign(string campaignId, string userId)
        => Send<DefaultRpcResponse>("DeleteCampaign", new() { { "campaignId", campaignId } }, userId);

    public Task<RpcResult<CampaignsResponse>> ListMyCampaigns(string userId)
        => Send<CampaignsResponse>("ListMyCampaigns", null, userId);

    public Task<RpcResult<DefaultRpcResponse>> AddMember(string campaignId, string targetUserId, string role, string userId)
        => Send<DefaultRpcResponse>("AddMember", new() { { "campaignId", campaignId }, { "targetUserId", targetUserId }, { "role", role } }, userId);

    public Task<RpcResult<DefaultRpcResponse>> RemoveMember(string campaignId, string targetUserId, string userId)
        => Send<DefaultRpcResponse>("RemoveMember", new() { { "campaignId", campaignId }, { "targetUserId", targetUserId } }, userId);

    public Task<RpcResult<DefaultRpcResponse>> UpdateMemberRole(string campaignId, string targetUserId, string role, string userId)
        => Send<DefaultRpcResponse>("UpdateMemberRole", new() { { "campaignId", campaignId }, { "targetUserId", targetUserId }, { "role", role } }, userId);

    public Task<RpcResult<MembersResponse>> ListMembers(string campaignId, string userId)
        => Send<MembersResponse>("ListMembers", new() { { "campaignId", campaignId } }, userId);

    public Task<RpcResult<ChapterResponse>> CreateChapter(string campaignId, string? parentId, string title, string? content, string userId)
    {
        var p = new Dictionary<string, object> { { "campaignId", campaignId }, { "title", title } };
        if (parentId != null) p["parentId"] = parentId;
        if (content != null) p["content"] = content;
        return Send<ChapterResponse>("CreateChapter", p, userId);
    }

    public Task<RpcResult<ChapterResponse>> GetChapter(string chapterId, string userId)
        => Send<ChapterResponse>("GetChapter", new() { { "chapterId", chapterId } }, userId);

    public Task<RpcResult<ChapterResponse>> UpdateChapter(string chapterId, string title, string? content, string userId)
    {
        var p = new Dictionary<string, object> { { "chapterId", chapterId }, { "title", title } };
        if (content != null) p["content"] = content;
        return Send<ChapterResponse>("UpdateChapter", p, userId);
    }

    public Task<RpcResult<DefaultRpcResponse>> DeleteChapter(string chapterId, string userId)
        => Send<DefaultRpcResponse>("DeleteChapter", new() { { "chapterId", chapterId } }, userId);

    public Task<RpcResult<DefaultRpcResponse>> MoveChapter(string chapterId, string? newParentId, string userId)
    {
        var p = new Dictionary<string, object> { { "chapterId", chapterId } };
        if (newParentId != null) p["newParentId"] = newParentId;
        return Send<DefaultRpcResponse>("MoveChapter", p, userId);
    }

    public Task<RpcResult<DefaultRpcResponse>> ReorderChapters(string campaignId, string? parentId, List<string> orderedIds, string userId)
    {
        var p = new Dictionary<string, object> { { "campaignId", campaignId }, { "orderedIds", orderedIds } };
        if (parentId != null) p["parentId"] = parentId;
        return Send<DefaultRpcResponse>("ReorderChapters", p, userId);
    }

    public Task<RpcResult<ChapterResponse>> SetChapterVisibility(string chapterId, bool isVisibleToAll, string userId)
        => Send<ChapterResponse>("SetChapterVisibility", new() { { "chapterId", chapterId }, { "isVisibleToAll", isVisibleToAll } }, userId);

    public Task<RpcResult<DefaultRpcResponse>> GrantChapterAccess(string chapterId, string targetUserId, string userId)
        => Send<DefaultRpcResponse>("GrantChapterAccess", new() { { "chapterId", chapterId }, { "targetUserId", targetUserId } }, userId);

    public Task<RpcResult<DefaultRpcResponse>> RevokeChapterAccess(string chapterId, string targetUserId, string userId)
        => Send<DefaultRpcResponse>("RevokeChapterAccess", new() { { "chapterId", chapterId }, { "targetUserId", targetUserId } }, userId);

    public Task<RpcResult<NoteResponse>> CreateNote(string chapterId, string title, string? content, string userId)
    {
        var p = new Dictionary<string, object> { { "chapterId", chapterId }, { "title", title } };
        if (content != null) p["content"] = content;
        return Send<NoteResponse>("CreateNote", p, userId);
    }

    public Task<RpcResult<NoteResponse>> GetNote(string noteId, string userId)
        => Send<NoteResponse>("GetNote", new() { { "noteId", noteId } }, userId);

    public Task<RpcResult<NoteResponse>> UpdateNote(string noteId, string title, string? content, string userId)
    {
        var p = new Dictionary<string, object> { { "noteId", noteId }, { "title", title } };
        if (content != null) p["content"] = content;
        return Send<NoteResponse>("UpdateNote", p, userId);
    }

    public Task<RpcResult<DefaultRpcResponse>> DeleteNote(string noteId, string userId)
        => Send<DefaultRpcResponse>("DeleteNote", new() { { "noteId", noteId } }, userId);

    public Task<RpcResult<NotesResponse>> ListChapterNotes(string chapterId, string userId)
        => Send<NotesResponse>("ListChapterNotes", new() { { "chapterId", chapterId } }, userId);

    public Task<RpcResult<DefaultRpcResponse>> ReorderNotes(string chapterId, List<string> orderedIds, string userId)
        => Send<DefaultRpcResponse>("ReorderNotes", new() { { "chapterId", chapterId }, { "orderedIds", orderedIds } }, userId);

    public Task<RpcResult<NoteResponse>> SetNoteVisibility(string noteId, bool isPublic, string userId)
        => Send<NoteResponse>("SetNoteVisibility", new() { { "noteId", noteId }, { "isPublic", isPublic } }, userId);

    public Task<RpcResult<DefaultRpcResponse>> GrantNoteAccess(string noteId, string targetUserId, string userId)
        => Send<DefaultRpcResponse>("GrantNoteAccess", new() { { "noteId", noteId }, { "targetUserId", targetUserId } }, userId);

    public Task<RpcResult<DefaultRpcResponse>> RevokeNoteAccess(string noteId, string targetUserId, string userId)
        => Send<DefaultRpcResponse>("RevokeNoteAccess", new() { { "noteId", noteId }, { "targetUserId", targetUserId } }, userId);
}