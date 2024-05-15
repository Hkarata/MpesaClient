using System.ComponentModel;
using Newtonsoft.Json;

namespace MpesaClient.Responses;

public record ApiResponse
{
    [Description("The result code for the transaction.")]
    [JsonProperty("output_ResponseCode")]
    public string ResponseCode { get; set; } = string.Empty;
    
    [Description("The result description for the transaction.")]
    [JsonProperty("output_ResponseDesc")]
    public string ResponseDescription { get; set; } = string.Empty;
    
    [Description("The transaction identifier that gets generated on the Mobile Money platform. This is used to query transactions on the Mobile Money Platform.")]
    [JsonProperty("output_TransactionID")]
    public string? TransactionId { get; set; } = string.Empty;
    
    [Description("The OpenAPI platform generates this as a reference to the transaction.")]
    [JsonProperty("output_ConversationID")]
    public Guid ConversationId { get; set; }
    
    [Description("The incoming reference from the third party system. When there are queries about transactions, this will usually be used to track a transaction.")]
    [JsonProperty("output_ThirdPartyConversationID")]
    public Guid ThirdPartyConversationId { get; set; } 
}