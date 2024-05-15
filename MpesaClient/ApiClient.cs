using MpesaClient.HttpMethodType;
using MpesaClient.Options;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System.ComponentModel;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using MpesaClient.Request;
using MpesaClient.Responses;
using Newtonsoft.Json;

namespace MpesaClient
{
    public class ApiClient(IOptions<ApiClientOptions> options, IHttpClientFactory httpClientFactory)
    {
        [Description("This is the API key obtained from the Mpesa portal, used for service access.")]
        private readonly string _apiKey = options.Value.ApiKey;

        [Description("This is the public key obtained from the Mpesa portal, used for encrypting the request payload.")]
        private readonly string _publicKey = options.Value.PublicKey;

        [Description("This is a boolean value that determines whether the request should be made over a secure connection. The default value is true")]
        private bool _ssl = options.Value.Ssl;

        [Description("This is the type of HTTP method to be used in making the request.")]
        public ApiMethodTypes MethodType;

        [Description("This is the address of the API endpoint.")]
        private string _address = options.Value.Address;

        [Description("This is the port number to be used in making the request. The default port is 80")]
        private int _port = options.Value.Port;

        [Description("This is the path to the API endpoint.")]
        private readonly string _path = options.Value.Path;

        [Description("This is a dictionary of headers to be included in the request.")]
        private readonly Dictionary<string, string> _headers = options.Value.Headers ?? new Dictionary<string, string>();

        [Description("This is a dictionary of parameters to be included in the request.")]
        private Dictionary<string, string> _parameters = options.Value.Parameters ?? new Dictionary<string, string>();

        private readonly HttpClient _httpClient = httpClientFactory.CreateClient();

        private string CreateBearerToken()
        {
            var key = (RsaKeyParameters)PublicKeyFactory.CreateKey(Convert.FromBase64String(_publicKey));
            var parameters = new RSAParameters
            {
                Modulus = key.Modulus.ToByteArrayUnsigned(),
                Exponent = key.Exponent.ToByteArrayUnsigned()
            };
            var cryptoServiceProvider = new RSACryptoServiceProvider();
            cryptoServiceProvider.ImportParameters(parameters);
            return Convert.ToBase64String(cryptoServiceProvider.Encrypt(Encoding.UTF8.GetBytes(_apiKey), false));
        }

        private void AddDefaultHeaders()
        {
            _headers.Add("Content-Type", "application/json");
            _headers.Add("Authorization", "Bearer" + this.CreateBearerToken());
            _headers.Add("Origin", "*");

            foreach (var header in _headers)
            {
                _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }

        public async Task<ApiResponse?> Post(ApiRequest request, CancellationToken cancellationToken)
        {
            AddDefaultHeaders();
            var response = await _httpClient.PostAsJsonAsync(_path, request, cancellationToken);
            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            var result = JsonConvert.DeserializeObject<ApiResponse>(content);
            return result;
        }

    }
}
