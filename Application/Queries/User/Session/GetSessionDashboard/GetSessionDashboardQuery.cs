using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Session.GetSessionDashboard;

// The dashboard: sessions open in the user's campaigns, the latest ones over, totals.
public class GetSessionDashboardQuery : UserRequest<SessionDashboardData>;
