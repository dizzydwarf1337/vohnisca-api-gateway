namespace Application.Core.Requests;

public class SortingSpecification
{
    public string? SortBy { get; set; }
    public string SortDir { get; set; } = "desc";
}