// File:    EquipmentService.cs
// Author:  Stefan
// Created: cetvrtak, 28. maj 2020. 03:14:12
// Purpose: Definition of Class EquipmentService

using Model.DoctorMenager;
using Model.Manager;
using Repository.RoomsRepository;
using System;
using System.Collections.Generic;

namespace Service.RoomsServices
{
    public class EquipmentService : IService<Equipment, int>
    {
        public IEquipmentRepository equipmentRepository;

        public EquipmentService(IEquipmentRepository equipmentRepository)
        {
            this.equipmentRepository = equipmentRepository;
        }

        public bool ExistEquipmentWithCode(String code)
        {
            foreach (Equipment equipment in this.GetAllEntities())
            {
                if (equipment.Code.Equals(code))
                    return true;
            }
            return false;
        }

        public Equipment AddExistingEquipmnet(String code, int amount)
        {
            foreach (Equipment equipment in this.GetAllEntities())
            {
                if (equipment.Code.Equals(code))
                {
                    equipment.Amount += amount;
                    this.UpdateEntity(equipment);
                    return equipment;
                }
            }
            return null;
        }

        public Equipment GetEntity(int id)
        {
            return equipmentRepository.GetEntity(id);
        }

        public IEnumerable<Equipment> GetAllEntities()
        {
            return equipmentRepository.GetAllEntities();
        }

        public Equipment AddEntity(Equipment entity)
        {
            return equipmentRepository.AddEntity(entity);
        }

        public void UpdateEntity(Equipment entity)
        {
            equipmentRepository.UpdateEntity(entity);
        }

        public void DeleteEntity(Equipment entity)
        {
            equipmentRepository.DeleteEntity(entity);
        }
        
    }
}