/***********************************************************************
 * Module:  DiagnosisService.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Service.ExaminationSurgeryServices.DiagnosisService
 ***********************************************************************/

using Model.PatientDoctor;
using Service.MedicalRecordService;
using System;
using System.Collections.Generic;

namespace Controller.MedicalRecordControlers
{
    public class DiagnosisController : IController<Diagnosis, int>
    {
        public DiagnosisService diagnosisService;

        public DiagnosisController(DiagnosisService diagnosisService)
        {
            this.diagnosisService = diagnosisService;
        }

        public Diagnosis AddEntity(Diagnosis entity)
        {
            return diagnosisService.AddEntity(entity);
        }

        public void DeleteEntity(Diagnosis entity)
        {
            diagnosisService.DeleteEntity(entity);
        }

        public IEnumerable<Diagnosis> GetAllEntities()
        {
            return diagnosisService.GetAllEntities();
        }

        public Diagnosis GetEntity(int id)
        {
            return diagnosisService.GetEntity(id);
        }

        public void UpdateEntity(Diagnosis entity)
        {
            diagnosisService.UpdateEntity(entity);
        }
    }
}