using System.Text.Json;
using Application.Core.ApiResponse;
using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Workshop.ClassBuilder;

// The workshop builders' calls (classes, subclasses, libraries, mechanics, and from stage 01 the NPC
// bestiary/character halves): a builder payload is deep and the workshop checks it, so the request and
// the answer pass through as JSON (camelCase both ways).
public class WorkshopBuilderRequest : UserRequest<JsonElement?>
{
    public string Method { get; init; } = string.Empty;
    public JsonElement Body { get; init; }

    public static readonly HashSet<string> Methods =
    [
        "ListClasses", "GetClassById", "CreateClass", "UpdateClass", "SetClassVisibility", "DeleteClass",
        "ListSubclasses", "GetSubclassById", "CreateSubclass", "UpdateSubclass", "SetSubclassVisibility", "DeleteSubclass",
        "ListLibrary", "AddToLibrary", "RemoveFromLibrary", "SetLibraryEnabled", "ListFeatureMechanics",
        "CreateNpcBestiary", "CreateNpcCharacter",
    ];
}

public class WorkshopBuilderRequestHandler : IRequestHandler<WorkshopBuilderRequest, ApiResponse<JsonElement?>>
{
    private readonly IWorkshopRpcClient _client;
    public WorkshopBuilderRequestHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<JsonElement?>> Handle(WorkshopBuilderRequest request, CancellationToken cancellationToken)
    {
        if (!WorkshopBuilderRequest.Methods.Contains(request.Method))
            return ApiResponse<JsonElement?>.Failure("Unknown workshop method", 404);
        return (await _client.Builder(request.Method, request.Body, request.Token!)).ToApiResponse(x => (JsonElement?)x, "Workshop error");
    }
}
