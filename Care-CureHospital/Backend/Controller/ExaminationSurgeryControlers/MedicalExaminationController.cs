/***********************************************************************
 * Module:  MedicalExaminationService.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Service.MedicalExaminationService
 ***********************************************************************/

using Model.Term;
using Model.AllActors;
using Service.ExaminationSurgeryServices;
using System;
using System.Collections.Generic;

namespace Controller.ExaminationSurgeryControlers
{
    public class MedicalExaminationController : IController<MedicalExamination, int>
    {
        public MedicalExaminationService medicalExaminationService;

        public MedicalExaminationController(MedicalExaminationService medicalExaminationService)
        {
            this.medicalExaminationService = medicalExaminationService;
        }

        public List<MedicalExamination> GetByDate(DateTime date)
        {
            return medicalExaminationService.GetByDate(date);
        }

        public List<MedicalExamination> GetAllMedicalExaminationsByDoctor(Doctor doctor)
        {
            return medicalExaminationService.GetAllMedicalExaminationsByDoctor(doctor);
        }

        public List<MedicalExamination> GetAllMedicalExaminationsByPatient(Patient patient)
        {
            return medicalExaminationService.GetAllMedicalExaminationsByPatient(patient);
        }

        public List<MedicalExamination> GetAllMedicalExaminationsByRoom(Room room)
        {
            return medicalExaminationService.GetAllMedicalExaminationsByRoom(room);
        }

        public MedicalExamination GetEntity(int id)
        {
            return medicalExaminationService.GetEntity(id);
        }

        public IEnumerable<MedicalExamination> GetAllEntities()
        {
            return medicalExaminationService.GetAllEntities();
        }

        public MedicalExamination AddEntity(MedicalExamination entity)
        {
            return medicalExaminationService.AddEntity(entity);
        }

        public void UpdateEntity(MedicalExamination entity)
        {
            medicalExaminationService.UpdateEntity(entity);
        }

        public void DeleteEntity(MedicalExamination entity)
        {
            medicalExaminationService.DeleteEntity(entity);
        }

    }
}