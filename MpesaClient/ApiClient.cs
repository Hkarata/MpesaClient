using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;

namespace MpesaClient
{
    public class ApiClient
    {
        [Description("This is the API key obtained from the Mpesa portal, used for service access.")]
        private string ApiKey = "";

        [Description("This is the public key obtained from the Mpesa portal, used for encrypting the request payload.")]
        private string PublicKey = "";

        [Description("This is a boolean value that determines whether the request should be made over a secure connection. The default value is true")]
        private bool Ssl = true;

        [Description("This is the type of HTTP method to be used in making the request.")]
        private ApiMethodTypes MethodType = ApiMethodTypes.GET;

        [Description("This is the address of the API endpoint.")]
        private string Address = "";

        [Description("This is the port number to be used in making the request. The default port is 80")]
        private int Port = 443;

        [Description("This is the path to the API endpoint.")]
        private string Path = "";

        [Description("This is a dictionary of headers to be included in the request.")]
        private Dictionary<string, string> Headers = new Dictionary<string, string>();

        [Description("This is a dictionary of parameters to be included in the request.")]
        private Dictionary<string, string> Parameters = new Dictionary<string, string>();

        private readonly HttpClient httpClient;

        public ApiClient(ApiClientOptions options, IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient();
            ApiKey = options.ApiKey;
            PublicKey = options.PublicKey;
            Ssl = options.Ssl;
            Address = options.Address;
            Port = options.Port;
            Path = options.Path;
            Headers = options.Headers ?? new Dictionary<string, string>();
            Parameters = options.Parameters ?? new Dictionary<string, string>();
        }

        private string CreateBearerToken()
        {
            RsaKeyParameters key = (RsaKeyParameters)PublicKeyFactory.CreateKey(Convert.FromBase64String(PublicKey));
            RSAParameters parameters = new RSAParameters();
            parameters.Modulus = key.Modulus.ToByteArrayUnsigned();
            parameters.Exponent = key.Exponent.ToByteArrayUnsigned();
            RSACryptoServiceProvider cryptoServiceProvider = new RSACryptoServiceProvider();
            cryptoServiceProvider.ImportParameters(parameters);
            return Convert.ToBase64String(cryptoServiceProvider.Encrypt(Encoding.UTF8.GetBytes(ApiKey), false));
        }

        private void AddDefaultHeaders()
        {
            Headers.Add("Content-Type", "application/json");
            Headers.Add("Authorization", "Bearer" + this.CreateBearerToken());
            Headers.Add("Origin", "*");
        }


    }
}
