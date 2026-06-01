using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.User.GetUser;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, ApiResponse<UserData>>
{
    private readonly IUserRpcClient _userRpcClient;

    public GetUserQueryHandler(IUserRpcClient userRpcClient)
        => _userRpcClient = userRpcClient;

    public async Task<ApiResponse<UserData>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var rpcResult = await _userRpcClient.GetUser(request.Id, request.Token);
        return rpcResult.ToApiResponse(data => data.Data, "Error while loading user data");
    }
}