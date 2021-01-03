// File:    IValidationOfMedicamentRepository.cs
// Author:  Stefan
// Created: cetvrtak, 28. maj 2020. 02:06:54
// Purpose: Definition of Interface IValidationOfMedicamentRepository

using Model.DoctorMenager;
using System;
using System.Collections.Generic;

namespace Repository.MedicamentRepository
{
    public interface IValidationOfMedicamentRepository : IRepository<ValidationOfMedicament, int>
    {
        List<ValidationOfMedicament> GetMedicamentsOnValidationForDoctor(Model.AllActors.Doctor doctor);

    }
}