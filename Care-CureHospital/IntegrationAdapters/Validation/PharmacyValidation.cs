using Backend;
using IntegrationAdapters.Dto;

namespace IntegrationAdapters.Validation
{
    public class PharmacyValidation
    {
        public PharmacyValidation()
        {

        }

        public bool ValidatePharmacy(PharmaciesDTO dto)
        {
            if(!ValidateName(dto.Name) || !ValidateKey(dto.Key))
            {
                return false;
            }
            return true;
        }

        private bool ValidateName(string name)
        {
            if(App.Instance().PharmacyService.DoesNameExist(name))
            {
                return false;
            }

            return true;
        }

        private bool ValidateKey(string key)
        {
            if(App.Instance().PharmacyService.DoesKeyExist(key))
            {
                return false;
            }
            return true;
        }
    }
}
