// File:    IHospitalitationRepository.cs
// Author:  Stefan
// Created: cetvrtak, 28. maj 2020. 00:41:35
// Purpose: Definition of Interface IHospitalitationRepository

using Model.Term;
using System;
using System.Collections.Generic;

namespace Repository.ExaminationSurgeryRepository
{
    public interface IHospitalitationRepository : IRepository<Hospitalitation, int>
    {
        List<Hospitalitation> GetAllHospitalitationsByRoom(Room room);

        List<Hospitalitation> GetByDate(DateTime date);
    }
}