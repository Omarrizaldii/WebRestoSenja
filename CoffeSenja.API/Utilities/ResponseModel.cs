using System.Text.Json.Serialization;

namespace CoffeSenja.API.Utilities
{
    public class ResponseModel
    {
        public int StatusCode { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Message { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object Data { get; set; }
    }
}