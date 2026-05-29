using Application.Core.Mediatr.Requests.UserRequest;
using Application.Core.Requests;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Campaign.Campaign.ListMyCampaigns;

public class ListMyCampaignsQuery : UserRequest<PaginatedCampaignsResult>
{
    public PaginationSpecification Pagination { get; set; } = new();
    public SortingSpecification Sorting { get; set; } = new();
    public ListMyCampaignsFilterSpecification Filters { get; set; } = new();
}

public class ListMyCampaignsFilterSpecification : IFilterSpecification
{
    public string? Status { get; set; }
    public string? Search { get; set; }

    public Dictionary<string, object> ToParameters()
    {
        var p = new Dictionary<string, object>();
        if (Status != null) p["status"] = Status;
        if (Search != null) p["search"] = Search;
        return p;
    }
}

public record PaginatedCampaignsResult(List<CampaignData> Campaigns, PaginationMeta Meta);