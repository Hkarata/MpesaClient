using System.ComponentModel;

namespace MpesaClient
{
    public class ApiClient
    {
        [Description("This is the API key obtained from the Mpesa portal, used for service access.")]
        private string apiKey = "";

        [Description("This is the public key obtained from the Mpesa portal, used for encrypting the request payload.")]
        private string publicKey = "";

        [Description("This is a boolean value that determines whether the request should be made over a secure connection.")]
        private bool ssl = false;

        [Description("This is the type of HTTP method to be used in making the request.")]
        private ApiMethodTypes methodType = ApiMethodTypes.GET;

        [Description("This is the address of the API endpoint.")]
        private string address = "";

        [Description("This is the port number to be used in making the request. The default port is 80")]
        private int port = 80;

        [Description("This is the path to the API endpoint.")]
        private string path = "";

        [Description("This is a dictionary of headers to be included in the request.")]
        private Dictionary<string, string> headers = new Dictionary<string, string>();

        [Description("This is a dictionary of parameters to be included in the request.")]
        private Dictionary<string, string> parameters = new Dictionary<string, string>();
    }
}
