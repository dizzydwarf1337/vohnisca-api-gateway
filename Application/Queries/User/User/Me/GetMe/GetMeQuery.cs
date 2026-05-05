using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.User.Me.GetMe;

public class GetMeQuery : UserRequest<UserData>;