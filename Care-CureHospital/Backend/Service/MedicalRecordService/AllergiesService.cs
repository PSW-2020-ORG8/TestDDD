// File:    AllergiesService.cs
// Author:  Stefan
// Created: cetvrtak, 28. maj 2020. 03:11:26
// Purpose: Definition of Class AllergiesService

using Model.PatientDoctor;
using Repository.MedicalRecordRepository;
using System;
using System.Collections.Generic;

namespace Service.MedicalRecordService
{
    public class AllergiesService : IService<Allergies, int>
    {
        public IAllergiesRepository allergiesRepository;

        public AllergiesService(IAllergiesRepository allergiesRepository)
        {
            this.allergiesRepository = allergiesRepository;
        }

        public Allergies GetEntity(int id)
        {
            return allergiesRepository.GetEntity(id);
        }

        public IEnumerable<Allergies> GetAllEntities()
        {
            return allergiesRepository.GetAllEntities();
        }

        public Allergies AddEntity(Allergies entity)
        {
            return allergiesRepository.AddEntity(entity);
        }

        public void UpdateEntity(Allergies entity)
        {
            allergiesRepository.UpdateEntity(entity);
        }

        public void DeleteEntity(Allergies entity)
        {
            allergiesRepository.DeleteEntity(entity);
        }
    }
}