// File:    IAllergiesRepository.cs
// Author:  Stefan
// Created: cetvrtak, 28. maj 2020. 00:27:44
// Purpose: Definition of Interface IAllergiesRepository

using Model.PatientDoctor;
using System;

namespace Repository.MedicalRecordRepository
{
    public interface IAllergiesRepository : IRepository<Allergies, int>
    {
    }
}