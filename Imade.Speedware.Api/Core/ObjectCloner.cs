using System.Text.Json;

namespace Imade.Speedware.Api.Core
{
    public static class ObjectCloner
    {
        public static T Clone<T>(this T source)
        {
            if (source is null)
                return default!;

            return JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(source))!;
        }
    }
}
