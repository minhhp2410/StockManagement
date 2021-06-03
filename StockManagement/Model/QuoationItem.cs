namespace StockManagement
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="QuoationItem" />.
    /// </summary>
    public class QuoationItem
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the QuotationID.
        /// </summary>
        [JsonProperty("quotationID")]
        public int QuotationID { get; set; }

        /// <summary>
        /// Gets or sets the PartNumber.
        /// </summary>
        [JsonProperty("partNumber")]
        public string PartNumber { get; set; }

        /// <summary>
        /// Gets or sets the PartName.
        /// </summary>
        [JsonProperty("partName")]
        public string PartName { get; set; }

        /// <summary>
        /// Gets or sets the Quantity.
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the UnitPrice.
        /// </summary>
        [JsonProperty("unitPrice")]
        public int UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the ActualNumber.
        /// </summary>
        [JsonProperty("actualNumber")]
        public int ActualNumber { get; set; }

        /// <summary>
        /// Gets or sets the Currency.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the Unit.
        /// </summary>
        [JsonProperty("unit")]
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets the UpdatedAt.
        /// </summary>
        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets the Store.
        /// </summary>
        [JsonProperty("store")]
        public string Store { get; set; }

        /// <summary>
        /// Gets or sets the Position.
        /// </summary>
        [JsonProperty("position")]
        public string Position { get; set; }
    }

    /// <summary>
    /// Defines the <see cref="QuoationItems" />.
    /// </summary>
    public class QuoationItems : List<QuoationItem>
    {
        /// <summary>
        /// Gets or sets the QuoationItemss.
        /// </summary>
        public string QuoationItemss { get; set; }
    }

    /// <summary>
    /// Defines the <see cref="JsonHeadQuoationItem" />.
    /// </summary>
    public class JsonHeadQuoationItem
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
        public QuoationItems Data { get; set; }
    }

    /// <summary>
    /// Defines the <see cref="JsonQuoationItem" />.
    /// </summary>
    public class JsonQuoationItem
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
        public QuoationItem Data { get; set; }
    }
}
