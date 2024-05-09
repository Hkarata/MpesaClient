using System.ComponentModel;

namespace MpesaClient.Request
{
    public record ApiRequest
    {
        [Description("The transaction amount. This amount will be moved from the organization's account to the customer's account")]
        public string input_Amount { get; set; } = string.Empty;

        [Description("The MSISDN of the customer where funds will be debited from.")]
        public string input_CustomerMSISDN { get; set; } = string.Empty;

        [Description("The country of the mobile money platform where the transaction needs happen on.")]
        public string input_Country { get; set; } = string.Empty;

        [Description("The currency in which the transaction should take place.")]
        public string input_Currency { get; set; } = string.Empty;

        [Description("The short code of the organization where funds will be credited to.")]
        public string input_ServiceProviderCode { get; set; } = string.Empty;

        [Description("The customer's transaction reference")]
        public string input_TransactionReference { get; set; } = string.Empty;

        [Description("The third party's transaction reference on their system.")]
        public string input_ThirdPartyConversationID { get; set; } = string.Empty;

        [Description("Description of purchased items")]
        public string input_PurchasedItemsDesc { get; set; } = string.Empty;
    }
}
