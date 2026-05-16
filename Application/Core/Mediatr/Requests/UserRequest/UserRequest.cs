using System.Text.Json.Serialization;

namespace Application.Core.Mediatr.Requests.UserRequest;

public class UserRequest<T> : AuthorizedRequest<T>, IUserRequest;

public interface IUserRequest
{
    [JsonIgnore] string? Token { get; set; }

    [JsonIgnore] Guid? UserId { get; set; }
}