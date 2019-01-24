using System;

namespace Quotation.Api.Swagger {
    /// <summary>
    /// Custom Schema Ids
    /// </summary>
    public static class CustomSchemaIds {
        /// <summary>
        /// Custom Schema Ids
        /// </summary>
        /// <param name="type"></param>
        public static string Format(Type type) {
            var name = type.Name;

            if (type.IsConstructedGenericType) {
                name = $"{type.Name}[{type.GenericTypeArguments[0].Name}]";
            }

            return name
               .Replace("1", string.Empty)
               .Replace("Get", string.Empty)
               .Replace("Body", string.Empty)
               .Replace("Response", string.Empty)
               .Replace("Request", string.Empty)
               .Replace("Model", string.Empty);
        }
    }
}
