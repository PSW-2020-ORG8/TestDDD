// File:    IWorkingTimeForDoctorRepository.cs
// Author:  Stefan
// Created: sreda, 27. maj 2020. 23:54:59
// Purpose: Definition of Interface IWorkingTimeForDoctorRepository

using Model.Term;
using System;
using System.Collections.Generic;

namespace Repository.UsersRepository
{
    public interface IWorkingTimeForDoctorRepository : IRepository<WorkingTimeForDoctor, int>
    {
        List<WorkingTimeForDoctor> GetWorkTimeForDoctor(Model.AllActors.Doctor doctor);
    }
}