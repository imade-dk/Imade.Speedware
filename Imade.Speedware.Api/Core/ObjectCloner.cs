using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Imade.Speedadmin.Api.Core
{
    public static class ObjectCloner
    {
        /// <summary>
        /// Perform a deep Copy of the object.
        /// </summary>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="source">The object instance to copy.</param>
        /// <returns>The copied object.</returns>
        public static T Clone<T>(this T source)
        {
            //if (!typeof(T).IsSerializable)
            //{
            //    throw new ArgumentException("The type must be serializable.", nameof(source));
            //}

            // Don't serialize a null object, simply return the default for that object
            if (source is null)
            {
                return default;
            }

            //IFormatter formatter = new BinaryFormatter();
            //Stream stream = new MemoryStream();
            //using (stream)
            //{
            //    formatter.Serialize(stream, source);
            //    stream.Seek(0, SeekOrigin.Begin);
            //    return (T)formatter.Deserialize(stream);
            //}
            var serialized = JsonSerializer.Serialize<T>(source);
            return JsonSerializer.Deserialize<T>(serialized);
        }
    }
}
