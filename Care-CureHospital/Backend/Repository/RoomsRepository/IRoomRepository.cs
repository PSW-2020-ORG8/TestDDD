// File:    IRoomRepository.cs
// Author:  Stefan
// Created: cetvrtak, 28. maj 2020. 00:13:34
// Purpose: Definition of Interface IRoomRepository

using Model.Term;
using System;

namespace Repository.RoomsRepository
{
    public interface IRoomRepository : IRepository<Room, int>
    {
    }
}