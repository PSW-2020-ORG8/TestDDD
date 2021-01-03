/***********************************************************************
 * Module:  HospitalitationService.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Service.HospitalitationService
 ***********************************************************************/
using Model.Doctor;
using Model.Term;
using System;
using System.Collections.Generic;
using Service.ExaminationSurgeryServices;

namespace Controller.ExaminationSurgeryControlers
{
   public class HospitalitationController : IController<Hospitalitation,int>
   {
        public HospitalitationService hospitalitationService;

        public HospitalitationController(HospitalitationService hospitalitationService)
        {
            this.hospitalitationService = hospitalitationService;
        }

        public List<Hospitalitation> GetAllHospitalitationsByRoom(Room room)
        {
            return hospitalitationService.GetAllHospitalitationsByRoom(room);
        }

        public List<Hospitalitation> GetByDate(DateTime date)
        {
            return hospitalitationService.GetByDate(date);
        }

        public Hospitalitation AddEntity(Hospitalitation entity)
        {
            return hospitalitationService.AddEntity(entity);
        }

        public void DeleteEntity(Hospitalitation entity)
        {
            hospitalitationService.DeleteEntity(entity);
        }

        public IEnumerable<Hospitalitation> GetAllEntities()
        {
            return hospitalitationService.GetAllEntities();
        }

        public Hospitalitation GetEntity(int id)
        {
            return hospitalitationService.GetEntity(id);
        }

        public void UpdateEntity(Hospitalitation entity)
        {
            hospitalitationService.UpdateEntity(entity);
        }
    }
}