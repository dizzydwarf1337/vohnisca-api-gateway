using Application.Core.Requests;
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

    public Task<RpcResult<CampaignResponse>> GetCampaign(string campaignId, string token)
        => Send<CampaignResponse>("GetCampaign", new() { { "campaignId", campaignId } }, token);

    public Task<RpcResult<CampaignResponse>> UpdateCampaign(string campaignId, string title, string? description, string token, string? status = null)
    {
        var p = new Dictionary<string, object> { { "campaignId", campaignId }, { "title", title } };
        if (description != null) p["description"] = description;
        if (status != null) p["status"] = status;
        return Send<CampaignResponse>("UpdateCampaign", p, token);
    }

    public Task<RpcResult<DefaultRpcResponse>> DeleteCampaign(string campaignId, string token)
        => Send<DefaultRpcResponse>("DeleteCampaign", new() { { "campaignId", campaignId } }, token);

    public Task<RpcResult<PaginatedCampaignsResponse>> ListMyCampaigns(PaginationSpecification pagination, SortingSpecification sorting, IFilterSpecification filters, string token)
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
        return Send<PaginatedCampaignsResponse>("ListMyCampaigns", p, token);
    }

    public Task<RpcResult<DefaultRpcResponse>> AddMember(string campaignId, string targetUserId, string role, string token)
        => Send<DefaultRpcResponse>("AddMember", new() { { "campaignId", campaignId }, { "targetUserId", targetUserId }, { "role", role } }, token);

    public Task<RpcResult<DefaultRpcResponse>> RemoveMember(string campaignId, string targetUserId, string token)
        => Send<DefaultRpcResponse>("RemoveMember", new() { { "campaignId", campaignId }, { "targetUserId", targetUserId } }, token);

    public Task<RpcResult<DefaultRpcResponse>> UpdateMemberRole(string campaignId, string targetUserId, string role, string token)
        => Send<DefaultRpcResponse>("UpdateMemberRole", new() { { "campaignId", campaignId }, { "targetUserId", targetUserId }, { "role", role } }, token);

    public Task<RpcResult<MembersResponse>> ListMembers(string campaignId, string token)
        => Send<MembersResponse>("ListMembers", new() { { "campaignId", campaignId } }, token);

    public Task<RpcResult<ChapterResponse>> CreateChapter(string campaignId, string? parentId, string title, string? content, string token)
    {
        var p = new Dictionary<string, object> { { "campaignId", campaignId }, { "title", title } };
        if (parentId != null) p["parentId"] = parentId;
        if (content != null) p["content"] = content;
        return Send<ChapterResponse>("CreateChapter", p, token);
    }

    public Task<RpcResult<ChapterResponse>> GetChapter(string chapterId, string token)
        => Send<ChapterResponse>("GetChapter", new() { { "chapterId", chapterId } }, token);

    public Task<RpcResult<ChapterResponse>> UpdateChapter(string chapterId, string title, string? content, string token)
    {
        var p = new Dictionary<string, object> { { "chapterId", chapterId }, { "title", title } };
        if (content != null) p["content"] = content;
        return Send<ChapterResponse>("UpdateChapter", p, token);
    }

    public Task<RpcResult<DefaultRpcResponse>> DeleteChapter(string chapterId, string token)
        => Send<DefaultRpcResponse>("DeleteChapter", new() { { "chapterId", chapterId } }, token);

    public Task<RpcResult<DefaultRpcResponse>> MoveChapter(string chapterId, string? newParentId, string token)
    {
        var p = new Dictionary<string, object> { { "chapterId", chapterId } };
        if (newParentId != null) p["newParentId"] = newParentId;
        return Send<DefaultRpcResponse>("MoveChapter", p, token);
    }

    public Task<RpcResult<DefaultRpcResponse>> ReorderChapters(string campaignId, string? parentId, List<string> orderedIds, string token)
    {
        var p = new Dictionary<string, object> { { "campaignId", campaignId }, { "orderedIds", orderedIds } };
        if (parentId != null) p["parentId"] = parentId;
        return Send<DefaultRpcResponse>("ReorderChapters", p, token);
    }

    public Task<RpcResult<ChapterResponse>> SetChapterVisibility(string chapterId, bool isVisibleToAll, string token)
        => Send<ChapterResponse>("SetChapterVisibility", new() { { "chapterId", chapterId }, { "isVisibleToAll", isVisibleToAll } }, token);

    public Task<RpcResult<DefaultRpcResponse>> GrantChapterAccess(string chapterId, string targetUserId, string token)
        => Send<DefaultRpcResponse>("GrantChapterAccess", new() { { "chapterId", chapterId }, { "targetUserId", targetUserId } }, token);

    public Task<RpcResult<DefaultRpcResponse>> RevokeChapterAccess(string chapterId, string targetUserId, string token)
        => Send<DefaultRpcResponse>("RevokeChapterAccess", new() { { "chapterId", chapterId }, { "targetUserId", targetUserId } }, token);

    public Task<RpcResult<DefaultRpcResponse>> SetCurrentChapter(string campaignId, string chapterId, string token)
        => Send<DefaultRpcResponse>("SetCurrentChapter", new() { { "campaignId", campaignId }, { "chapterId", chapterId } }, token);

    public Task<RpcResult<ChaptersResponse>> ListCampaignChapters(string campaignId, string token)
        => Send<ChaptersResponse>("ListCampaignChapters", new() { { "campaignId", campaignId } }, token);

    public Task<RpcResult<NoteResponse>> CreateNote(string chapterId, string title, string? content, string token)
    {
        var p = new Dictionary<string, object> { { "chapterId", chapterId }, { "title", title } };
        if (content != null) p["content"] = content;
        return Send<NoteResponse>("CreateNote", p, token);
    }

    public Task<RpcResult<NoteResponse>> GetNote(string noteId, string token)
        => Send<NoteResponse>("GetNote", new() { { "noteId", noteId } }, token);

    public Task<RpcResult<NoteResponse>> UpdateNote(string noteId, string title, string? content, string token)
    {
        var p = new Dictionary<string, object> { { "noteId", noteId }, { "title", title } };
        if (content != null) p["content"] = content;
        return Send<NoteResponse>("UpdateNote", p, token);
    }

    public Task<RpcResult<DefaultRpcResponse>> DeleteNote(string noteId, string token)
        => Send<DefaultRpcResponse>("DeleteNote", new() { { "noteId", noteId } }, token);

    public Task<RpcResult<NotesResponse>> ListChapterNotes(string chapterId, string token)
        => Send<NotesResponse>("ListChapterNotes", new() { { "chapterId", chapterId } }, token);

    public Task<RpcResult<DefaultRpcResponse>> ReorderNotes(string chapterId, List<string> orderedIds, string token)
        => Send<DefaultRpcResponse>("ReorderNotes", new() { { "chapterId", chapterId }, { "orderedIds", orderedIds } }, token);

    public Task<RpcResult<NoteResponse>> SetNoteVisibility(string noteId, bool isPublic, string token)
        => Send<NoteResponse>("SetNoteVisibility", new() { { "noteId", noteId }, { "isPublic", isPublic } }, token);

    public Task<RpcResult<DefaultRpcResponse>> GrantNoteAccess(string noteId, string targetUserId, string token)
        => Send<DefaultRpcResponse>("GrantNoteAccess", new() { { "noteId", noteId }, { "targetUserId", targetUserId } }, token);

    public Task<RpcResult<DefaultRpcResponse>> RevokeNoteAccess(string noteId, string targetUserId, string token)
        => Send<DefaultRpcResponse>("RevokeNoteAccess", new() { { "noteId", noteId }, { "targetUserId", targetUserId } }, token);
}