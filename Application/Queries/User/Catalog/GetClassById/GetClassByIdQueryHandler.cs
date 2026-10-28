using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Catalog.GetClassById;

public class GetClassByIdQueryHandler : IRequestHandler<GetClassByIdQuery, ApiResponse<ClassDetail>>
{
    private readonly IWorkshopRpcClient _client;
    public GetClassByIdQueryHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<ClassDetail>> Handle(GetClassByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.GetClassById(request.Id, request.Token!);
        return result.ToApiResponse(x => x, "Error getting class");
    }
}
