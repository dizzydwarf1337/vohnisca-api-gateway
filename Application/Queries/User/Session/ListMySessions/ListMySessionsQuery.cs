using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Session.ListMySessions;

// Sessions open in the user's campaigns.
public class ListMySessionsQuery : UserRequest<List<SessionNoticeData>>;
