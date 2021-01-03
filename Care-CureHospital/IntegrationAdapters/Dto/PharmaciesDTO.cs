using System;
using Backend.Model.Pharmacy;

namespace IntegrationAdapters.Dto
{
    public class PharmaciesDTO
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public String Key { get; set; }

        public String Link { get; set; }

        public PharmaciesDTO()
        {

        }

        public PharmaciesDTO(Pharmacies pharmacy)
        {
            Id = pharmacy.GetId();
            Name = pharmacy.GetName();
            Key = pharmacy.GetKey();
            Link = pharmacy.GetLink();
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public String GetName()
        {
            return Name;
        }

        public void SetName(String name)
        {
            Name = name;
        }

        public String GetKey()
        {
            return Key;
        }

        public void SetKey(String key)
        {
            Key = key;
        }

        public String GetLink()
        {
            return Link;
        }

        public void SetLink(String link)
        {
            Link = link;
        }
    }
}
