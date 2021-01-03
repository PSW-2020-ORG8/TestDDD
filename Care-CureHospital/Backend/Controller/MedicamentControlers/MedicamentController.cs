// File:    MedicamentController.cs
// Author:  Hacer
// Created: subota, 30. maj 2020. 20:29:30
// Purpose: Definition of Class MedicamentController

using Model.DoctorMenager;
using Service.MedicamentService;
using System;
using System.Collections.Generic;

namespace Controller.MedicamentControlers
{
    public class MedicamentController : IController<Medicament, int>
    {
        public MedicamentService medicamentService;

        public MedicamentController(MedicamentService medicamentService)
        {
            this.medicamentService = medicamentService;
        }

        public List<Medicament> GetComfirmedMedicaments()
        {
            return medicamentService.GetComfirmedMedicaments();
        }

        public Medicament AddExistingMedicament(String medicamentID, int quantity)
        {
            return medicamentService.AddExistingMedicament(medicamentID, quantity);
        }

        public Medicament GetMedicamentByCode(String code)
        {
            return medicamentService.GetMedicamentByCode(code);
        }

        public bool ExistMedicamentWithCode(String code)
        {
            return medicamentService.ExistMedicamentWithCode(code);
        }

        public Medicament GetEntity(int id)
        {
            return medicamentService.GetEntity(id);
        }

        public IEnumerable<Medicament> GetAllEntities()
        {
            return medicamentService.GetAllEntities();
        }

        public Medicament AddEntity(Medicament entity)
        {
            return medicamentService.AddEntity(entity);
        }

        public void UpdateEntity(Medicament entity)
        {
            medicamentService.UpdateEntity(entity);
        }

        public void DeleteEntity(Medicament entity)
        {
            medicamentService.DeleteEntity(entity);
        }

    }
}