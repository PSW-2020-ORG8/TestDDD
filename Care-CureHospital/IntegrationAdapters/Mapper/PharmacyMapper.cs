using Backend.Model.Pharmacy;
using IntegrationAdapters.Dto;

namespace IntegrationAdapters.Mapper
{
    public class PharmacyMapper
    {
        public static Pharmacies PharmacyDtoToPharmacy(PharmaciesDTO dto)
        {
            Pharmacies pharmacy = new Pharmacies();
            pharmacy.Name = dto.Name;
            pharmacy.Key = dto.Key;
            pharmacy.Link = dto.Link;
            return pharmacy;
        }

        public static PharmaciesDTO PharmacyToPharmacyDto(Pharmacies pharmacy)
        {
            PharmaciesDTO dto = new PharmaciesDTO();
            dto.Name = pharmacy.Name;
            dto.Key = pharmacy.Key;
            dto.Link = pharmacy.Link;
            return dto;
        }
    }
}
