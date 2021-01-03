// File:    ISymptomsRepository.cs
// Author:  Stefan
// Created: cetvrtak, 28. maj 2020. 00:28:19
// Purpose: Definition of Interface ISymptomsRepository

using Model.PatientDoctor;
using System;

namespace Repository.MedicalRecordRepository
{
    public interface ISymptomsRepository : IRepository<Symptoms, int>
    {
    }
}