/***********************************************************************
 * Module:  AllergiesService.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Service.ExaminationSurgeryServices.AllergiesService
 ***********************************************************************/

using Model.PatientDoctor;
using Service.MedicalRecordService;
using System;
using System.Collections.Generic;

namespace Controller.MedicalRecordControlers
{
    public class AllergiesController : IController<Allergies, int>
    {
        public AllergiesService allergiesService;

        public AllergiesController(AllergiesService allergiesService)
        {
            this.allergiesService = allergiesService;
        }

        public Allergies AddEntity(Allergies entity)
        {
            return allergiesService.AddEntity(entity);
        }

        public void DeleteEntity(Allergies entity)
        {
            allergiesService.DeleteEntity(entity);
        }

        public IEnumerable<Allergies> GetAllEntities()
        {
            return allergiesService.GetAllEntities();
        }

        public Allergies GetEntity(int id)
        {
            return allergiesService.GetEntity(id);
        }

        public void UpdateEntity(Allergies entity)
        {
            allergiesService.UpdateEntity(entity);
        }
    }
}