using System.Text.Json;
using System.Text.Json.Serialization;
using Artisan.III.Shared.Models.Catan.Hexes;

namespace Artisan.III.Shared.JsonConverters;

public class HexCoordinatesJsonConverter : JsonConverter<HexCoordinates>
{
    public override HexCoordinates Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return HexCoordinates.FromString(reader.GetString()!);
    }

    public override void Write(Utf8JsonWriter writer, HexCoordinates value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}