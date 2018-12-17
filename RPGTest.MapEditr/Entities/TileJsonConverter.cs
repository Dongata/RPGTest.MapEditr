using Newtonsoft.Json;
using RPGTest.MapEditr.Components;
using System;

namespace RPGTest.MapEditr.Entities
{
    public class TileJsonConverter : JsonConverter<TileView>
    {
        public override TileView ReadJson(JsonReader reader, Type objectType, TileView existingValue, bool hasExistingValue, JsonSerializer serializer) => throw new NotImplementedException();
        public override void WriteJson(JsonWriter writer, TileView value, JsonSerializer serializer)
        {
            if (value.Image.Name != "Empty")
            {
                writer.WriteStartObject();

                writer.WritePropertyName(nameof(value.X));
                writer.WriteValue(value.X);

                writer.WritePropertyName(nameof(value.Y));
                writer.WriteValue(value.Y);

                writer.WritePropertyName("Image");

                writer.WriteStartObject();
                writer.WritePropertyName("Path");
                writer.WriteValue(value.Image.Name);

                writer.WriteEndObject();

                writer.WriteEndObject();
            }
        }
    }
}
