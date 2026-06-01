using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.User.UpdateUserData;

public class UpdateUserDataCommandHandler : IRequestHandler<UpdateUserDataCommand, ApiResponse<Unit>>
{
    private readonly IUserRpcClient _userRpcClient;

    public UpdateUserDataCommandHandler(IUserRpcClient userRpcClient)
        => _userRpcClient = userRpcClient;

    public async Task<ApiResponse<Unit>> Handle(UpdateUserDataCommand request, CancellationToken cancellationToken)
    {
        var rpcResult = await _userRpcClient.UpdateUserData(request.UserData, request.Token);
        return rpcResult.ToApiResponse(_ => Unit.Value, "Error while updating data");
    }
}