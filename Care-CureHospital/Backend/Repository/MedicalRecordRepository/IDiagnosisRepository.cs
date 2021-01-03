// File:    IDiagnosisRepository.cs
// Author:  Stefan
// Created: cetvrtak, 28. maj 2020. 00:27:57
// Purpose: Definition of Interface IDiagnosisRepository

using Model.PatientDoctor;
using System;

namespace Repository.MedicalRecordRepository
{
    public interface IDiagnosisRepository : IRepository<Diagnosis, int>
    {
    }
}