namespace Application.Core.Requests;

public interface IFilterSpecification
{
    Dictionary<string, object> ToParameters();
}