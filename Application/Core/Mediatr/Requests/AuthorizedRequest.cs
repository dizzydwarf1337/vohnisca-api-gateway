using System.Text.Json.Serialization;

namespace Application.Core.Mediatr.Requests;

public class AuthorizedRequest<T> : RequestBase<T>
{
    [JsonIgnore] public Guid? UserId { get; set; }

    [JsonIgnore] public string? Token { get; set; }

    // The client's Idempotency-Key header: it marks a command the client may have to send
    // again, and goes on to the service, which answers a repeat as it answered the first time.
    [JsonIgnore] public string? IdempotencyKey { get; set; }
}