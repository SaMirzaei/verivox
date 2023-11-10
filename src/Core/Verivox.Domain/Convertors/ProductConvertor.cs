using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Verivox.Domain.Entities;

namespace Verivox.Domain.Convertors
{
    public class ProductConvertor : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            string type = jsonObject["type"]?.Value<string>();

            if (type is null)
            {
                throw new InvalidOperationException("Missing 'Type' property in JSON");
            }

            switch (type)
            {
                case "1":
                    return jsonObject.ToObject<BasicTariffElectricityProduct>(); break;
                case "2":
                    return jsonObject.ToObject<PackagedTariffElectricityProduct>();
                    break;
                default:
                    throw new InvalidOperationException($"Unknown shape type: {type}");
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(ElectricityProduct).IsAssignableFrom(objectType);
        }
    }
}
