using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Catalog.GetFeatureById;

public class GetFeatureByIdQuery : UserRequest<FeatureDetail>
{
    public Guid Id { get; set; }
}
