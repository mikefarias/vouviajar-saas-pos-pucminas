using System.Text.Json.Serialization;

namespace VouViajar.API.Extensions
{
    public static class JsonExtension
    {
        public static IMvcBuilder AddCustomJsonOptions(this IMvcBuilder builder)
        {
            builder.AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

            });
            return builder;
        }
    }
}
