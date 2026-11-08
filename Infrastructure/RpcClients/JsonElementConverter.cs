using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace Infrastructure.RpcClients;

// EdjCase deserializes through Newtonsoft, which has no support for System.Text.Json types: a JSON-RPC
// `meta` would come back as an unusable JsonElement and would be sent out as {"ValueKind":1}.
public class JsonElementConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
        => objectType == typeof(JsonElement) || objectType == typeof(JsonElement?);

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null)
            return null;

        var token = JToken.Load(reader);
        using var document = JsonDocument.Parse(token.ToString(Formatting.None));
        return document.RootElement.Clone();
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value is null)
        {
            writer.WriteNull();
            return;
        }

        JToken.Parse(((JsonElement)value).GetRawText()).WriteTo(writer);
    }
}