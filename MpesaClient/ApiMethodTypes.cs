using System.ComponentModel;

namespace MpesaClient
{
    public enum ApiMethodTypes
    {
        [Description("Get request")]
        GET = 0,

        [Description("Post request")]
        POST = 1,

        [Description("Put request")]
        PUT = 3,

        [Description("Delete request")]
        DELETE = 4,
    }
}
