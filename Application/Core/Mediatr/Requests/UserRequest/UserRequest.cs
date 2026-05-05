namespace Application.Core.Mediatr.Requests.UserRequest;

public class UserRequest<T> : AuthorizedRequest<T>, IUserRequest;

public interface IUserRequest
{
    string Token { get; set; }
    Guid? UserId { get; set; }
}