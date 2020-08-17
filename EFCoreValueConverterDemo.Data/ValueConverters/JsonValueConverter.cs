using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace EFCoreValueConverterDemo.Data.ValueConverters
{
    public class JsonValueConverter<T> : ValueConverter<T, string>
    {
        public JsonValueConverter(JsonSerializerSettings settings = null)
            : base (
                  entity => JsonConvert.SerializeObject(entity, settings),
                  value => JsonConvert.DeserializeObject<T>(value, settings)
                  )
        { }
    }
}
