// File:    SymptomsService.cs
// Author:  Stefan
// Created: cetvrtak, 28. maj 2020. 03:11:26
// Purpose: Definition of Class SymptomsService

using Model.PatientDoctor;
using Repository.MedicalRecordRepository;
using System;
using System.Collections.Generic;

namespace Service.MedicalRecordService
{
    public class SymptomsService : IService<Symptoms, int>
    {
        public ISymptomsRepository symptomsRepository;

        public SymptomsService(ISymptomsRepository symptomsRepository)
        {
            this.symptomsRepository = symptomsRepository;
        }

        public Symptoms GetEntity(int id)
        {
            return symptomsRepository.GetEntity(id);
        }

        public IEnumerable<Symptoms> GetAllEntities()
        {
            return symptomsRepository.GetAllEntities();
        }

        public Symptoms AddEntity(Symptoms entity)
        {
            return symptomsRepository.AddEntity(entity);
        }

        public void UpdateEntity(Symptoms entity)
        {
            symptomsRepository.UpdateEntity(entity);
        }

        public void DeleteEntity(Symptoms entity)
        {
            symptomsRepository.DeleteEntity(entity);
        }
    }
}