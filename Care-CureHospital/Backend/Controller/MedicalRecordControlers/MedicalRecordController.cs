/***********************************************************************
 * Module:  MedicalRecordService.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Service.MedicalRecordService
 ***********************************************************************/

using Model.PatientDoctor;
using Service.MedicalRecordService;
using Model.AllActors;
using System;
using System.Collections.Generic;

namespace Controller.MedicalRecordControlers
{
    public class MedicalRecordController : IController<MedicalRecord, int>
    {
        public MedicalRecordService medicalRecordService;

        public MedicalRecordController(MedicalRecordService medicalRecordService)
        {
            this.medicalRecordService = medicalRecordService;
        }

        public MedicalRecord GetMedicalRecordByPatient(Patient patient)
        {
            return medicalRecordService.GetMedicalRecordByPatient(patient);
        }

        public MedicalRecord GetEntity(int id)
        {
            return medicalRecordService.GetEntity(id);
        }

        public IEnumerable<MedicalRecord> GetAllEntities()
        {
            return medicalRecordService.GetAllEntities();
        }

        public MedicalRecord AddEntity(MedicalRecord entity)
        {
            return medicalRecordService.AddEntity(entity);
        }

        public void UpdateEntity(MedicalRecord entity)
        {
            medicalRecordService.UpdateEntity(entity);
        }

        public void DeleteEntity(MedicalRecord entity)
        {
            medicalRecordService.DeleteEntity(entity);
        }

    }
}