// File:    IEquipmentRepository.cs
// Author:  Stefan
// Created: cetvrtak, 28. maj 2020. 00:13:47
// Purpose: Definition of Interface IEquipmentRepository

using Model.Manager;
using System;

namespace Repository.RoomsRepository
{
    public interface IEquipmentRepository : IRepository<Equipment, int>
    {
    }
}