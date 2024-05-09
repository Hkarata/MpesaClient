using System.ComponentModel;

namespace MpesaClient.HttpMethodType
{
    public enum ApiMethodTypes
    {
        [Description("Http Get request")]
        GET = 0,

        [Description("Http Post request")]
        POST = 1,

        [Description("Http Put request")]
        PUT = 3,

        [Description("Http Delete request")]
        DELETE = 4,
    }
}
