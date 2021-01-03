// File:    IMedicamentRepository.cs
// Author:  Stefan
// Created: cetvrtak, 28. maj 2020. 00:35:30
// Purpose: Definition of Interface IMedicamentRepository

using Model.DoctorMenager;
using System;

namespace Repository.MedicamentRepository
{
    public interface IMedicamentRepository : IRepository<Medicament, int>
    {
        
    }
}