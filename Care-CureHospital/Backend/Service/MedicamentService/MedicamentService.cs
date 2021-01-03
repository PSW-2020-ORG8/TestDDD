// File:    MedicamentService.cs
// Author:  Stefan
// Created: cetvrtak, 28. maj 2020. 03:37:00
// Purpose: Definition of Class MedicamentService


using Model.DoctorMenager;
using Repository.MedicamentRepository;
using System;
using System.Collections.Generic;

namespace Service.MedicamentService
{
    public class MedicamentService : IService<Medicament, int>
    {
        public IMedicamentRepository medicamentRepository;

        public MedicamentService(IMedicamentRepository medicamentRepository)
        {
            this.medicamentRepository = medicamentRepository;
        }

        public List<Medicament> GetComfirmedMedicaments() 
        {
            List<Medicament> confirmedMedicaments = new List<Medicament>();
            foreach (Medicament medicament in this.GetAllEntities())
                if (medicament.StateOfValidation == State.Confirmed)
                    confirmedMedicaments.Add(medicament);
            return confirmedMedicaments;
        }

        public Medicament AddExistingMedicament(String code, int quantity)
        {
            foreach (Medicament medicament in this.GetAllEntities())
            {
                if (medicament.Code.Equals(code))
                {
                    medicament.Quantity += quantity;
                    this.UpdateEntity(medicament);
                    return medicament;
                }
            }
            return null;
        }

        public bool ExistMedicamentWithCode(String code)
        {
            foreach (Medicament medicament in this.GetAllEntities())
            {
                if (medicament.Code.Equals(code))
                    return true;
            }
            return false;
        }

        public Medicament GetMedicamentByCode(String code)
        {
            foreach (Medicament medicament in this.GetAllEntities())
                if (medicament.Code.Equals(code))
                    return medicament;
            return null;
        }

        public Medicament GetEntity(int id)
        {
            return medicamentRepository.GetEntity(id);
        }

        public IEnumerable<Medicament> GetAllEntities()
        {
            return medicamentRepository.GetAllEntities();
        }

        

        public Medicament AddEntity(Medicament entity)
        {
            return medicamentRepository.AddEntity(entity);
        }

        public void UpdateEntity(Medicament entity)
        {
            medicamentRepository.UpdateEntity(entity);
        }

        public void DeleteEntity(Medicament entity)
        {
            medicamentRepository.DeleteEntity(entity);
        }

    }
}