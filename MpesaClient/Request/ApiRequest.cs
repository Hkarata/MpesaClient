using System.ComponentModel;
using Newtonsoft.Json;

namespace MpesaClient.Request
{
    public record ApiRequest
    {
        [Description("The transaction amount. This amount will be moved from the organization's account to the customer's account")]
        [JsonProperty("input_Amount")]
        public string InputAmount { get; set; } = string.Empty;

        [Description("The MSISDN of the customer where funds will be debited from.")]
        [JsonProperty("input_CustomerMSISDN")]
        public string InputCustomerMsisdn { get; set; } = string.Empty;

        [Description("The country of the mobile money platform where the transaction needs happen on.")]
        [JsonProperty("input_Country")]
        public string InputCountry { get; set; } = string.Empty;

        [Description("The currency in which the transaction should take place.")]
        [JsonProperty("input_Currency")]
        public string InputCurrency { get; set; } = string.Empty;

        [Description("The short code of the organization where funds will be credited to.")]
        [JsonProperty("input_ServiceProviderCode")]
        public string InputServiceProviderCode { get; set; } = string.Empty;

        [Description("The customer's transaction reference")]
        [JsonProperty("input_TransactionReference")]
        public string InputTransactionReference { get; set; } = string.Empty;

        [Description("The third party's transaction reference on their system.")]
        [JsonProperty("input_ThirdPartyConversationID")]
        public string InputThirdPartyConversationId { get; set; } = string.Empty;

        [Description("Description of purchased items")]
        [JsonProperty("input_PurchasedItemsDesc")]
        public string InputPurchasedItemsDesc { get; set; } = string.Empty;
    }
}
