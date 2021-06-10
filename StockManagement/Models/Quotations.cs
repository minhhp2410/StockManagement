using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace StockManagement.Model
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class PO
    {
        [JsonProperty("poNumber")]
        public string PoNumber { get; set; }
    }

    public class Supplier
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class QuotationItem
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("quotationID")]
        public int QuotationID { get; set; }

        [JsonProperty("partNumber")]
        public string PartNumber { get; set; }

        [JsonProperty("partName")]
        public string PartName { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("unitPrice")]
        public int UnitPrice { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("createdAt")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime? UpdatedAt { get; set; }
    }

    public class QuotationDatum
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("poID")]
        public int PoID { get; set; }

        [JsonProperty("supplierID")]
        public int SupplierID { get; set; }

        [JsonProperty("quotationNo")]
        public string QuotationNo { get; set; }

        [JsonProperty("issuedDate")]
        public DateTime IssuedDate { get; set; }

        [JsonProperty("validUntil")]
        public DateTime ValidUntil { get; set; }

        [JsonProperty("approved")]
        public object Approved { get; set; }

        [JsonProperty("approvedBy")]
        public object ApprovedBy { get; set; }

        [JsonProperty("approvedTime")]
        public object ApprovedTime { get; set; }

        [JsonProperty("createdAt")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("PO")]
        public PO PO { get; set; }

        [JsonProperty("Supplier")]
        public Supplier Supplier { get; set; }

        [JsonProperty("QuotationItems")]
        public List<QuotationItem> QuotationItems { get; set; }
    }

    public class Quotations
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public List<QuotationDatum> Data { get; set; }
    }


}
