// *******************************************************************************
// Filename       : CalculationTypesRecord.cs
// Type           : Class
// Function       : Calculation Types Data Transfer Object
// *******************************************************************************

using Newtonsoft.Json;

namespace Api.DataModels
{
    public class CalculationTypesRecord
    {
        [JsonProperty("ID")]
        public int ID { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }
    }
}