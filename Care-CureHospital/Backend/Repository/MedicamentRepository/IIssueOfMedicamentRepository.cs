// File:    IissueMedicamentRepository.cs
// Author:  Stefan
// Created: cetvrtak, 28. maj 2020. 00:35:41
// Purpose: Definition of Interface IissueMedicamentRepository

using Model.Doctor;
using System;

namespace Repository.MedicamentRepository
{
    public interface IIssueOfMedicamentRepository : IRepository<IssueOfMedicaments, int>
    {
    }
}