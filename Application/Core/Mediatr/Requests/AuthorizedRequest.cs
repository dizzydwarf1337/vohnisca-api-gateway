namespace Application.Core.Mediatr.Requests;

public class AuthorizedRequest<T> : RequestBase<T>
{
    public Guid? UserId { get; set; }
}