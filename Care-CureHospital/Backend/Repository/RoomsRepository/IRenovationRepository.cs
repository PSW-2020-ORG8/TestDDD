// File:    IRenovationRepository.cs
// Author:  Stefan
// Created: cetvrtak, 28. maj 2020. 00:13:53
// Purpose: Definition of Interface IRenovationRepository

using Model.Term;
using System;

namespace Repository.RoomsRepository
{
    public interface IRenovationRepository : IRepository<Renovation, int>
    {
    }
}