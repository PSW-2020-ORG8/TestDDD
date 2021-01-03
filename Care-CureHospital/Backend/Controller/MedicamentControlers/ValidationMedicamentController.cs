/***********************************************************************
 * Module:  ValidationMedicamentService.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Service.ValidationMedicamentService
 ***********************************************************************/

using Model.AllActors;
using Model.DoctorMenager;
using Service.MedicamentService;
using System;
using System.Collections.Generic;

namespace Controller.MedicamentControlers
{
    public class ValidationMedicamentController : IController<ValidationOfMedicament, int>
    {
        public ValidationMedicamentService validationMedicamentService;

        public ValidationMedicamentController(ValidationMedicamentService validationMedicamentService)
        {
            this.validationMedicamentService = validationMedicamentService;
        }

        public ValidationOfMedicament GetMedicamentOnValidationByCodeOfMedicament(int medicamentID)
        {
            return validationMedicamentService.GetMedicamentOnValidationByCodeOfMedicament(medicamentID);
        }

        public List<ValidationOfMedicament> GetMedicamentsOnValidationForDoctor(Doctor doctor)
        {
            return validationMedicamentService.GetMedicamentsOnValidationForDoctor(doctor);
        }

        public ValidationOfMedicament AddEntity(ValidationOfMedicament entity)
        {
            return validationMedicamentService.AddEntity(entity);
        }

        public void DeleteEntity(ValidationOfMedicament entity)
        {
            validationMedicamentService.DeleteEntity(entity);
        }

        public IEnumerable<ValidationOfMedicament> GetAllEntities()
        {
            return validationMedicamentService.GetAllEntities();
        }

        public ValidationOfMedicament GetEntity(int id)
        {
            return validationMedicamentService.GetEntity(id);
        }

        public void UpdateEntity(ValidationOfMedicament entity)
        {
            validationMedicamentService.UpdateEntity(entity);
        }
    }
}