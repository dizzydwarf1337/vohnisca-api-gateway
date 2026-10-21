using Application.Core.Mediatr.Requests.UserRequest;
using Application.Core.Responses;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Catalog.ListFeatures;

public class ListFeaturesQuery : UserRequest<PaginationResponse<FeatureListRow>>
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 100;
    public bool OnlySelectableAsFeat { get; set; }
}
