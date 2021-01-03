/***********************************************************************
 * Module:  MedicalExaminationService.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Service.MedicalExaminationService
 ***********************************************************************/

using Model.Term;
using Model.AllActors;
using Repository.ExaminationSurgeryRepository;
using System;
using System.Collections.Generic;

namespace Service.ExaminationSurgeryServices
{
    public class SurgeryService : IService<Surgery, int>
    {
        public ISurgeryRepository surgeryRepository;

        public SurgeryService(ISurgeryRepository surgeryRepository)
        {
            this.surgeryRepository = surgeryRepository;
        }

        public List<Surgery> GetByDate(DateTime date)
        {
            List<Surgery> surgeries = new List<Surgery>();
            foreach (Surgery m in surgeryRepository.GetAllEntities())
            {
                if (m.FromDateTime.Equals(date))
                {
                    surgeries.Add(m);
                }
            }

            return surgeries;
        }

        public List<Surgery> GetAllSurgeryByDoctor(Doctor doctor)
        {
            return surgeryRepository.GetAllSurgeryByDoctor(doctor);
        }

        public List<Surgery> GetAllSurgeryByPatient(Patient patient)
        {
            return surgeryRepository.GetAllSurgeryByPatient(patient);
        }

        public List<Surgery> GetAllSurgeryByRoom(Room room)
        {
            return surgeryRepository.GetAllSurgeryByRoom(room);
        }


        public Surgery GetEntity(int id)
        {
            return surgeryRepository.GetEntity(id);
        }

        public IEnumerable<Surgery> GetAllEntities()
        {
            return surgeryRepository.GetAllEntities();
        }

        public Surgery AddEntity(Surgery entity)
        {
            return surgeryRepository.AddEntity(entity);
        }

        public void UpdateEntity(Surgery entity)
        {
            surgeryRepository.UpdateEntity(entity);
        }

        public void DeleteEntity(Surgery entity)
        {
            surgeryRepository.DeleteEntity(entity);
        }

    }
}