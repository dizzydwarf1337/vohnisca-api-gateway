using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Catalog.GetInstanceCharges;

// I-08: one instance's charges, for the campaign card that stands for it (the registry's state, not the item's rule).
public class GetInstanceChargesQuery : UserRequest<InstanceChargesData>
{
    public Guid InstanceId { get; set; }
    public Guid ItemId { get; set; }
}
