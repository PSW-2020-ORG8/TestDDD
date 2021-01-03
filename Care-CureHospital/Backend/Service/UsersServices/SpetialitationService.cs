// File:    SpetialitationService.cs
// Author:  Stefan
// Created: cetvrtak, 28. maj 2020. 03:47:24
// Purpose: Definition of Class SpetialitationService

using Model.Doctor;
using System;
using System.Collections.Generic;
using Repository.UsersRepository;

namespace Service.UsersServices
{
    public class SpetialitationService : IService<Specialitation, int>
    {
        public ISpecialitationRepository specialitationRepository;

        public SpetialitationService(ISpecialitationRepository specialitationRepository)
        {
            this.specialitationRepository = specialitationRepository;
        }

        public Specialitation AddEntity(Specialitation entity)
        {
            return specialitationRepository.AddEntity(entity);
        }

        public void DeleteEntity(Specialitation entity)
        {
            specialitationRepository.DeleteEntity(entity);
        }

        public IEnumerable<Specialitation> GetAllEntities()
        {
            return specialitationRepository.GetAllEntities();
        }

        public Specialitation GetEntity(int id)
        {
            return specialitationRepository.GetEntity(id);
        }

        public void UpdateEntity(Specialitation entity)
        {
            specialitationRepository.UpdateEntity(entity);
        }
    }
}