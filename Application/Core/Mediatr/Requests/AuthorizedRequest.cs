using System.Text.Json.Serialization;

namespace Application.Core.Mediatr.Requests;

public class AuthorizedRequest<T> : RequestBase<T>
{
    [JsonIgnore] public Guid? UserId { get; set; }

    [JsonIgnore] public string? Token { get; set; }
}