using System.Text.Json;
using Esign.Application.Interfaces.Serialization.Options;

namespace Esign.Application.Serialization.Options
{
    public class SystemTextJsonOptions : IJsonSerializerOptions
    {
        public JsonSerializerOptions JsonSerializerOptions { get; } = new();
    }
}