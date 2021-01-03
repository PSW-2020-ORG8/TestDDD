/***********************************************************************
 * Module:  HospitalitationService.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Service.HospitalitationService
 ***********************************************************************/

using Model.Term;
using Repository.ExaminationSurgeryRepository;
using System;
using System.Collections.Generic;

namespace Service.ExaminationSurgeryServices
{
    public class HospitalitationService : IService<Hospitalitation, int>
    {
        public IHospitalitationRepository hospitalitationRepository;

        public HospitalitationService(IHospitalitationRepository hospitalitationRepository)
        {
            this.hospitalitationRepository = hospitalitationRepository;
        }

        public List<Hospitalitation> GetAllHospitalitationsByRoom(Room room)
        {
            return hospitalitationRepository.GetAllHospitalitationsByRoom(room);
        }

        public List<Hospitalitation> GetByDate(DateTime date)
        {
            return hospitalitationRepository.GetByDate(date);
        }

        public Hospitalitation GetEntity(int id)
        {
            return hospitalitationRepository.GetEntity(id);
        }

        public IEnumerable<Hospitalitation> GetAllEntities()
        {
            return hospitalitationRepository.GetAllEntities();
        }

        public Hospitalitation AddEntity(Hospitalitation entity)
        {
            return hospitalitationRepository.AddEntity(entity);
        }

        public void UpdateEntity(Hospitalitation entity)
        {
            hospitalitationRepository.UpdateEntity(entity);
        }

        public void DeleteEntity(Hospitalitation entity)
        {
            hospitalitationRepository.DeleteEntity(entity);
        }

    }
}