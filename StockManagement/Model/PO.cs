namespace StockManagement.Model
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="PO" />.
    /// </summary>
    public class PO
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the PoNumber.
        /// </summary>
        [JsonProperty("poNumber")]
        public string PoNumber { get; set; }

        /// <summary>
        /// Gets or sets the CustomerID.
        /// </summary>
        [JsonProperty("customerID")]
        public int CustomerID { get; set; }

        /// <summary>
        /// Gets or sets the IssuedDate.
        /// </summary>
        [JsonProperty("issuedDate")]
        public DateTime IssuedDate { get; set; }

        /// <summary>
        /// Gets or sets the DeliveryDate.
        /// </summary>
        [JsonProperty("deliveryDate")]
        public DateTime DeliveryDate { get; set; }

        /// <summary>
        /// Gets or sets the PaymentTerms.
        /// </summary>
        [JsonProperty("paymentTerms")]
        public string PaymentTerms { get; set; }

        /// <summary>
        /// Gets or sets the PoStatus.
        /// </summary>
        [JsonProperty("poStatus")]
        public string PoStatus { get; set; }

        /// <summary>
        /// Gets or sets the Customers.
        /// </summary>
        [JsonProperty("Customer")]
        public Cus Customers { get; set; }

        /// <summary>
        /// Gets or sets the CreatedBy.
        /// </summary>
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the UpdatedAt.
        /// </summary>
        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }

    /// <summary>
    /// Defines the <see cref="POs" />.
    /// </summary>
    public class POs : List<PO>
    {
        /// <summary>
        /// Gets or sets the POss.
        /// </summary>
        public string POss { get; set; }
    }

    /// <summary>
    /// Defines the <see cref="JsonHeadPO" />.
    /// </summary>
    public class JsonHeadPO
    {
        /// <summary>
        /// Gets or sets the Status.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the Message.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the Data.
        /// </summary>
        [JsonProperty("data")]
        public POs Data { get; set; }
    }

    /// <summary>
    /// Defines the <see cref="JsonPO" />.
    /// </summary>
    public class JsonPO
    {
        /// <summary>
        /// Gets or sets the Status.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the Message.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the Data.
        /// </summary>
        [JsonProperty("data")]
        public PO Data { get; set; }
    }

    /// <summary>
    /// Defines the <see cref="Cus" />.
    /// </summary>
    public class Cus
    {
        /// <summary>
        /// Gets or sets the NAME.
        /// </summary>
        [JsonProperty("name")]
        public string NAME { get; set; }
    }
}
