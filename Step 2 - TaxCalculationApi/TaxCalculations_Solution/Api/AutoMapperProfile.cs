using AutoMapper;

namespace Api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // ----- Mapping Data Models - Calculated Tax History ----- //
            CreateMap<DomainModels.DataModels.CalculatedTaxHistory_Item_ResponseRecord, DataModels.CalculatedTaxHistory_Item_ResponseRecord>().ReverseMap();
            CreateMap<DomainModels.DataModels.CalculatedTaxHistory_List_ResponseRecord, DataModels.CalculatedTaxHistory_List_ResponseRecord>().ReverseMap();
            CreateMap<DomainModels.DataModels.CalculatedTaxHistoryRecord, DataModels.CalculatedTaxHistoryRecord>().ReverseMap();

            // ----- Mapping Data Models - Calculation Types ----- //
            CreateMap<DomainModels.DataModels.CalculationTypes_Item_ResponseRecord, DataModels.CalculationTypes_Item_ResponseRecord>().ReverseMap();
            CreateMap<DomainModels.DataModels.CalculationTypes_List_ResponseRecord, DataModels.CalculationTypes_List_ResponseRecord>().ReverseMap();
            CreateMap<DomainModels.DataModels.CalculationTypesRecord, DataModels.CalculationTypesRecord>().ReverseMap();

            // ----- Mapping Data Models - Postal Code Master ----- //
            CreateMap<DomainModels.DataModels.PostalCodeMaster_Item_ResponseRecord, DataModels.PostalCodeMaster_Item_ResponseRecord>().ReverseMap();
            CreateMap<DomainModels.DataModels.PostalCodeMaster_List_ResponseRecord, DataModels.PostalCodeMaster_List_ResponseRecord>().ReverseMap();
            CreateMap<DomainModels.DataModels.PostalCodeMasterRecord, DataModels.PostalCodeMasterRecord>().ReverseMap();

            // ----- Mapping Data Models - Tax Calculation ----- //
            CreateMap<DomainModels.DataModels.TaxCalculation_Item_ResponseRecord, DataModels.TaxCalculation_Item_ResponseRecord>().ReverseMap();
            CreateMap<DomainModels.DataModels.TaxCalculation_List_ResponseRecord, DataModels.TaxCalculation_List_ResponseRecord>().ReverseMap();
            CreateMap<DomainModels.DataModels.TaxCalculationRecord, DataModels.TaxCalculationRecord>().ReverseMap();

            // ----- Mapping Data Models - Tax Calculation Types ----- //
            CreateMap<DomainModels.DataModels.TaxCalculationTypes_Item_ResponseRecord, DataModels.TaxCalculationTypes_Item_ResponseRecord>().ReverseMap();
            CreateMap<DomainModels.DataModels.TaxCalculationTypes_List_ResponseRecord, DataModels.TaxCalculationTypes_List_ResponseRecord>().ReverseMap();
            CreateMap<DomainModels.DataModels.TaxCalculationTypesRecord, DataModels.TaxCalculationTypesRecord>().ReverseMap();

            // ----- Mapping Data Models - Tax Rules ----- //
            CreateMap<DomainModels.DataModels.TaxRules_Item_ResponseRecord, DataModels.TaxRules_Item_ResponseRecord>().ReverseMap();
            CreateMap<DomainModels.DataModels.TaxRules_List_ResponseRecord, DataModels.TaxRules_List_ResponseRecord>().ReverseMap();
            CreateMap<DomainModels.DataModels.TaxRulesRecord, DataModels.TaxRulesRecord>().ReverseMap();
        }
    }
}
