// File:    EquipmentController.cs
// Author:  Hacer
// Created: subota, 30. maj 2020. 20:26:06
// Purpose: Definition of Class EquipmentController

using Model.DoctorMenager;
using Model.Manager;
using Service.RoomsServices;
using System;
using System.Collections.Generic;

namespace Controller.RoomsControlers
{
    public class EquipmentController : IController<Equipment, int>
    {
        public EquipmentService equipmentService;

        public EquipmentController(EquipmentService equipmentService)
        {
            this.equipmentService = equipmentService;
        }

        public Equipment GetEntity(int id)
        {
            return equipmentService.GetEntity(id);
        }

        public IEnumerable<Equipment> GetAllEntities()
        {
            return equipmentService.GetAllEntities();
        }

        public Equipment AddEntity(Equipment entity)
        {
            return equipmentService.AddEntity(entity);
        }

        public void UpdateEntity(Equipment entity)
        {
            equipmentService.UpdateEntity(entity);
        }

        public void DeleteEntity(Equipment entity)
        {
            equipmentService.DeleteEntity(entity);
        }

        public bool ExistEquipmentWithCode(String code)
        {
            return equipmentService.ExistEquipmentWithCode(code);
        }

        public Equipment AddExistingEquipmnet(String code, int amount)
        {
            return equipmentService.AddExistingEquipmnet(code, amount);
        }

    }
}