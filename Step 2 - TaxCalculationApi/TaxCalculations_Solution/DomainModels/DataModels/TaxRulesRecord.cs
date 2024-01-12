// *******************************************************************************
// Filename       : TaxRulesRecord.cs
// Type           : Class
// Function       : Tax Rules Data Transfer Object
// *******************************************************************************

namespace DomainModels.DataModels
{
    public class TaxRulesRecord
    {
        public int ID { get; set; }
        public int TaxCalculationTypeID { get; set; }
        public decimal FromAmount { get; set; }
        public decimal ToAmount { get; set; }
        public int CalculationTypeID { get; set; }
        public decimal CalculationValue { get; set; }
    }
}