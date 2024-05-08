using System.ComponentModel;

namespace MpesaClient
{
    public class ApiResponse
    {
        [Description("This represents the response’s status code.")]
        public string StatusCode { get; set; } = string.Empty;

        [Description("This represents a collection of header fields included in the response, structured as a dictionary.")]
        public Dictionary<string, string>? Headers;

        [Description("This represents the response body, structured as a dictionary.")]
        public Dictionary<string, string>? Body;
    }
}
