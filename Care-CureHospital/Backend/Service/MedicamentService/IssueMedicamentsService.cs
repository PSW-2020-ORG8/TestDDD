// File:    IssueMedicamentsService.cs
// Author:  Stefan
// Created: cetvrtak, 28. maj 2020. 03:10:35
// Purpose: Definition of Class IssueMedicamentsService

using Model.Doctor;
using Repository.MedicamentRepository;
using System;
using System.Collections.Generic;

namespace Service.MedicamentService
{
    public class IssueMedicamentsService : IService<IssueOfMedicaments, int>
    {
        public IIssueOfMedicamentRepository issueOfMedicamentRepository;

        public IssueMedicamentsService(IIssueOfMedicamentRepository issueOfMedicamentRepository)
        {
            this.issueOfMedicamentRepository = issueOfMedicamentRepository;
        }

        public IssueOfMedicaments GetEntity(int id)
        {
            return issueOfMedicamentRepository.GetEntity(id);
        }

        public IEnumerable<IssueOfMedicaments> GetAllEntities()
        {
            return issueOfMedicamentRepository.GetAllEntities();
        }

        public IssueOfMedicaments AddEntity(IssueOfMedicaments entity)
        {
            return issueOfMedicamentRepository.AddEntity(entity);
        }

        public void UpdateEntity(IssueOfMedicaments entity)
        {
            issueOfMedicamentRepository.UpdateEntity(entity);
        }

        public void DeleteEntity(IssueOfMedicaments entity)
        {
            issueOfMedicamentRepository.DeleteEntity(entity);
        }

    }
}