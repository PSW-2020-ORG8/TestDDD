// File:    IMedicalRecordRepository.cs
// Author:  Stefan
// Created: cetvrtak, 28. maj 2020. 00:28:07
// Purpose: Definition of Interface IMedicalRecordRepository

using Model.PatientDoctor;
using System;

namespace Repository.MedicalRecordRepository
{
    public interface IMedicalRecordRepository : IRepository<MedicalRecord, int>
    {
        Model.PatientDoctor.MedicalRecord GetMedicalRecordByPatient(Model.AllActors.Patient patient);

    }
}