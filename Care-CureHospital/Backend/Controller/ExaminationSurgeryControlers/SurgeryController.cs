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
    public class SurgeryController : IController<Surgery, int>
    {
        public SurgeryService surgeryService;

        public SurgeryController(SurgeryService surgeryService)
        {
            this.surgeryService = surgeryService;
        }

        public List<Surgery> GetByDate(DateTime date)
        {
            return surgeryService.GetByDate(date);
        }

        public List<Surgery> GetAllSurgeryByDoctor(Doctor doctor)
        {
            return surgeryService.GetAllSurgeryByDoctor(doctor);
        }

        public List<Surgery> GetAllSurgeryByPatient(Patient patient)
        {
            return surgeryService.GetAllSurgeryByPatient(patient);
        }

        public List<Surgery> GetAllSurgeryByRoom(Room room)
        {
            return surgeryService.GetAllSurgeryByRoom(room);
        }

        public Surgery GetEntity(int id)
        {
            return surgeryService.GetEntity(id);
        }

        public IEnumerable<Surgery> GetAllEntities()
        {
            return surgeryService.GetAllEntities();
        }

        public Surgery AddEntity(Surgery entity)
        {
            return surgeryService.AddEntity(entity);
        }

        public void UpdateEntity(Surgery entity)
        {
            surgeryService.UpdateEntity(entity);
        }

        public void DeleteEntity(Surgery entity)
        {
            surgeryService.DeleteEntity(entity);
        }

    }
}