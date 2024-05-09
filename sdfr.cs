public class ApiClient
{
    private readonly HttpClient httpClient;

    // ... existing fields ...

    public ApiClient(ApiClientOptions options, IHttpClientFactory httpClientFactory)
    {
        this.httpClient = httpClientFactory.CreateClient();
        this.apiKey = options.ApiKey;
        this.publicKey = options.PublicKey;
        this.ssl = options.Ssl;
        this.methodType = options.MethodType;
        this.address = options.Address;
        this.port = options.Port;
        this.path = options.Path;
        this.headers = options.Headers ?? new Dictionary<string, string>();
        this.parameters = options.Parameters ?? new Dictionary<string, string>();
    }

    // ... existing methods ...
}
