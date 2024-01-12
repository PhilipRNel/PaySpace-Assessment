// *******************************************************************************
// Filename       : CalculatedTaxHistoryRecord.cs
// Type           : Class
// Function       : Calculated Tax History Data Transfer Object
// *******************************************************************************

namespace DomainModels.DataModels
{
    public class CalculatedTaxHistoryRecord
    {
        public int ID { get; set; }
        public string PostalCode { get; set; }
        public decimal AnnualIncome { get; set; }
        public decimal CalculatedTax { get; set; }
        public DateTime CalculatedDateTime { get; set; }
    }
}