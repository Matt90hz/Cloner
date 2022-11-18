using Newtonsoft.Json;
using System;

namespace Cloner
{
    /// <summary>
    /// Contains methods to clone objects.
    /// </summary>
    public static class Cloner
    {
        /// <summary>
        /// Clone an object by serializing it into JSON formato and deserializize it into a new object.
        /// By defaut the reference loop handling is ignored. Use <paramref name="optionsBuilder"/> to change this behaviour.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="optionsBuilder"></param>
        /// <returns>
        /// New object the has the same values and the same reference values in fields and properties.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// The exception should never throw is not necessary cach it.
        /// </exception>
        public static T Clone<T>(this T source, Action<JsonSerializerSettings>? optionsBuilder = null) where T : class
        {
            JsonSerializerSettings serializerSettings = new()
            {
                ObjectCreationHandling = ObjectCreationHandling.Replace,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            optionsBuilder?.Invoke(serializerSettings);

            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source, serializerSettings), serializerSettings) ?? throw new ArgumentNullException(nameof(source));
        }

    }
}