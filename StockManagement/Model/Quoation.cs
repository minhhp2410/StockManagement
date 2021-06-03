namespace StockManagement
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="Quoation" />.
    /// </summary>
    public class Quoation
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the PoID.
        /// </summary>
        [JsonProperty("poID")]
        public int PoID { get; set; }

        /// <summary>
        /// Gets or sets the SupplierID.
        /// </summary>
        [JsonProperty("supplierID")]
        public int SupplierID { get; set; }

        /// <summary>
        /// Gets or sets the IssuedDate.
        /// </summary>
        [JsonProperty("issuedDate")]
        public DateTime IssuedDate { get; set; }

        /// <summary>
        /// Gets or sets the ValidUntil.
        /// </summary>
        [JsonProperty("validUntil")]
        public DateTime ValidUntil { get; set; }

        /// <summary>
        /// Gets or sets the Approved.
        /// </summary>
        [JsonProperty("approved")]
        public Boolean Approved { get; set; }

        /// <summary>
        /// Gets or sets the ApprovedBy.
        /// </summary>
        [JsonProperty("approvedBy")]
        public int ApprovedBy { get; set; }

        /// <summary>
        /// Gets or sets the ApprovedTime.
        /// </summary>
        [JsonProperty("approvedTime")]
        public DateTime ApprovedTime { get; set; }

        /// <summary>
        /// Gets or sets the Suppliers.
        /// </summary>
        [JsonProperty("Supplier")]
        public Sup Suppliers { get; set; }

        /// <summary>
        /// Gets or sets the UpdatedAt.
        /// </summary>
        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }

    /// <summary>
    /// Defines the <see cref="Quoations" />.
    /// </summary>
    public class Quoations : List<Quoation>
    {
        /// <summary>
        /// Gets or sets the Quoationss.
        /// </summary>
        public string Quoationss { get; set; }
    }

    /// <summary>
    /// Defines the <see cref="Sup" />.
    /// </summary>
    public class Sup
    {
        /// <summary>
        /// Gets or sets the NAME.
        /// </summary>
        [JsonProperty("name")]
        public string NAME { get; set; }
    }

    /// <summary>
    /// Defines the <see cref="JsonHeadQuoation" />.
    /// </summary>
    public class JsonHeadQuoation
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
        public Quoations Data { get; set; }
    }

    /// <summary>
    /// Defines the <see cref="JsonQuoation" />.
    /// </summary>
    public class JsonQuoation
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
        public Quoation Data { get; set; }
    }
}
