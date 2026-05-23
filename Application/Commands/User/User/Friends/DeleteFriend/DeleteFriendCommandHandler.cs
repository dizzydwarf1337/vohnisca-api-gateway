using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.User.Friends.DeleteFriend;

public class DeleteFriendCommandHandler : IRequestHandler<DeleteFriendCommand, ApiResponse<Unit>>
{
    private readonly IUserRpcClient _userRpcClient;

    public DeleteFriendCommandHandler(IUserRpcClient userRpcClient)
        => _userRpcClient = userRpcClient;

    public async Task<ApiResponse<Unit>> Handle(DeleteFriendCommand request, CancellationToken cancellationToken)
    {
        var result = await _userRpcClient.DeleteFriend(request.Id, request.Token);
        return result.ToApiResponse(_ => Unit.Value, "Error while deleting friend");
    }
}