// File:    IUserRepository.cs
// Author:  Stefan
// Created: sreda, 27. maj 2020. 23:37:36
// Purpose: Definition of Interface IUserRepository

using Model.AllActors;
using Model.Doctor;
using System;
using System.Collections.Generic;

namespace Repository.UsersRepository
{
    public interface IUserRepository : IRepository<User, int>
    {
        List<Doctor> GetAllDoctors();

        List<Patient> GetAllPatients();

        List<Secretary> GetAllSecretaries();

        List<Manager> GetAllManagers();

        User GetUserByUsername(String username);

        List<Doctor> GetDoctorBySpecialitation(Specialitation specialitation);

        User GetUserByJMBG(String jmbg);

    }
}