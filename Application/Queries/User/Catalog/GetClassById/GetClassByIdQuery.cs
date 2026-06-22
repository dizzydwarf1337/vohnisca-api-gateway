using Application.Core.ApiResponse;
using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Catalog.GetClassById;

public class GetClassByIdQuery : UserRequest<ClassDetail>
{
    public Guid Id { get; set; }
}

public class GetClassByIdQueryHandler : IRequestHandler<GetClassByIdQuery, ApiResponse<ClassDetail>>
{
    private readonly ICharacterRpcClient _client;
    public GetClassByIdQueryHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<ClassDetail>> Handle(GetClassByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.GetClassById(request.Id, request.Token!);
        return result.ToApiResponse(x => x, "Error getting class");
    }
}
