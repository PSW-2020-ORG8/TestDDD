using Backend.Model.Pharmacy;
using Backend.Repository.PharmacyRepository;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service.PharmaciesService
{
    public class PharmacyService : IService<Pharmacies, int>
    {
        public IPharmacyRepository pharmacyRepository;

        public PharmacyService(IPharmacyRepository pharmacyRepository)
        {
            this.pharmacyRepository = pharmacyRepository;
        }

        public Pharmacies GetEntity(int id)
        {
            return pharmacyRepository.GetEntity(id);
        }

        public IEnumerable<Pharmacies> GetAllNames()
        {
            return pharmacyRepository.GetAllNames();
        }

        public IEnumerable<Pharmacies> GetAllEntities()
        {
            return pharmacyRepository.GetAllEntities();
        }

        public Pharmacies AddEntity(Pharmacies entity)
        {
            return pharmacyRepository.AddEntity(entity);
        }

        public void UpdateEntity(Pharmacies entity)
        {
            pharmacyRepository.UpdateEntity(entity);
        }

        public void DeleteEntity(Pharmacies entity)
        {
            pharmacyRepository.DeleteEntity(entity);
        }

        public bool DoesNameExist(string name)
        {
            foreach (Pharmacies pharmacy in GetAllEntities())
                if (pharmacy.Name.Equals(name))
                    return true;
            return false;
        }

        public bool DoesKeyExist(string key)
        {
            foreach (Pharmacies pharmacy in GetAllEntities())
                if (pharmacy.Key.Equals(key))
                    return true;
            return false;
        }

        
    }
}
