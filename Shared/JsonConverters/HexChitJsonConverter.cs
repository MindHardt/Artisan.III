using System.Text.Json;
using System.Text.Json.Serialization;
using Artisan.III.Shared.Models.Catan.Hexes;

namespace Artisan.III.Shared.JsonConverters;

public class HexChitJsonConverter : JsonConverter<HexChit>
{
    public override HexChit Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return HexChit.FromNumber(reader.GetByte());
    }

    public override void Write(Utf8JsonWriter writer, HexChit value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value.Number);
    }
}