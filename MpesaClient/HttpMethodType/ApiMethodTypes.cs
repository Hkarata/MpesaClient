using System.ComponentModel;

namespace MpesaClient.HttpMethodType
{
    public enum ApiMethodTypes
    {
        [Description("Http Get request")]
        Get = 0,

        [Description("Http Post request")]
        Post = 1,

        [Description("Http Put request")]
        Put = 3,

        [Description("Http Delete request")]
        Delete = 4,
    }
}
