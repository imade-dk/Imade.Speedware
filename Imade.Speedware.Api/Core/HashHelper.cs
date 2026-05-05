using System.Collections.Generic;

namespace Imade.Speedware.Api.Core
{
    internal static class HashHelper
    {
        internal const int FnvSeed = unchecked((int)2166136261);

        internal static int HashCollection(int seed, IEnumerable<int>? collection)
        {
            if (collection is null) return seed;
            return unchecked((seed * 16777619) ^ string.Join(",", collection).GetHashCode());
        }

        internal static int HashValue<T>(int seed, T? value) where T : struct
        {
            if (value is null) return seed;
            return unchecked((seed * 16777619) ^ value.GetHashCode());
        }

        internal static int HashString(int seed, string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) return seed;
            return unchecked((seed * 16777619) ^ value.GetHashCode());
        }
    }
}
