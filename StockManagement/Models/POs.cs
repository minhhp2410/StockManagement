using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace StockManagement.Model
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Customer
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class POPIC
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("picID")]
        public int PicID { get; set; }

        [JsonProperty("roles")]
        public string Roles { get; set; }
    }

    public class POItem
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("poID")]
        public int PoID { get; set; }

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
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }

    public class Quotation
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
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }

    public class POStepMaster
    {
        [JsonProperty("stepName")]
        public string StepName { get; set; }
    }

    public class POStep
    {
        [JsonProperty("poID")]
        public int PoID { get; set; }

        [JsonProperty("stepID")]
        public int StepID { get; set; }

        [JsonProperty("priority")]
        public string Priority { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("POStepMaster")]
        public POStepMaster POStepMaster { get; set; }
    }

    public class PoDatum
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("poNumber")]
        public string PoNumber { get; set; }

        [JsonProperty("customerID")]
        public int CustomerID { get; set; }

        [JsonProperty("issuedDate")]
        public DateTime IssuedDate { get; set; }

        [JsonProperty("deliveryDate")]
        public DateTime DeliveryDate { get; set; }

        [JsonProperty("paymentTerms")]
        public string PaymentTerms { get; set; }

        [JsonProperty("poStatus")]
        public object PoStatus { get; set; }

        [JsonProperty("createdBy")]
        public object CreatedBy { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("Customer")]
        public Customer Customer { get; set; }

        [JsonProperty("POPICs")]
        public List<POPIC> POPICs { get; set; }

        [JsonProperty("POItems")]
        public List<POItem> POItems { get; set; }

        [JsonProperty("Quotations")]
        public List<Quotation> Quotations { get; set; }

        [JsonProperty("POSteps")]
        public List<POStep> POSteps { get; set; }
    }

    public class POs
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public List<PoDatum> Data { get; set; }
    }


}
