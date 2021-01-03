/***********************************************************************
 * Module:  SymptomsService.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Service.ExaminationSurgeryServices.SymptomsService
 ***********************************************************************/

using Model.PatientDoctor;
using Service.MedicalRecordService;
using System;
using System.Collections.Generic;

namespace Controller.MedicalRecordControlers
{
    public class SymptomsController : IController<Symptoms, int>
    {
        public SymptomsService symptomsService;

        public SymptomsController(SymptomsService symptomsService)
        {
            this.symptomsService = symptomsService;
        }

        public Symptoms AddEntity(Symptoms entity)
        {
            return symptomsService.AddEntity(entity);
        }

        public void DeleteEntity(Symptoms entity)
        {
            symptomsService.DeleteEntity(entity);
        }

        public IEnumerable<Symptoms> GetAllEntities()
        {
            return symptomsService.GetAllEntities();
        }

        public Symptoms GetEntity(int id)
        {
            return symptomsService.GetEntity(id);
        }

        public void UpdateEntity(Symptoms entity)
        {
            symptomsService.UpdateEntity(entity);
        }
    }
}