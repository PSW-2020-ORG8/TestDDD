// File:    ISpecialitationRepository.cs
// Author:  Stefan
// Created: sreda, 27. maj 2020. 23:53:11
// Purpose: Definition of Interface ISpecialitationRepository

using Model.Doctor;
using System;

namespace Repository.UsersRepository
{
    public interface ISpecialitationRepository : IRepository<Specialitation, int>
    {
    }
}