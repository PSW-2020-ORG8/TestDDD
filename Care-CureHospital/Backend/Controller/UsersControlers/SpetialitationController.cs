
// File:    SpetialitationController.cs
// Author:  Hacer
// Created: subota, 30. maj 2020. 20:25:24
// Purpose: Definition of Class SpetialitationController

using Model.Doctor;
using Service.UsersServices;
using System;

namespace Controller.UsersControlers
{
    public class SpetialitationController : IController<Specialitation, int>
    {
        public SpetialitationService spetialitationService;

        public SpetialitationController(SpetialitationService spetialitationService)
        {
            this.spetialitationService = spetialitationService;
        }

        public Specialitation AddEntity(Specialitation entity)
        {
            return spetialitationService.AddEntity(entity);
        }

        public void DeleteEntity(Specialitation entity)
        {
            spetialitationService.DeleteEntity(entity);
        }

        public System.Collections.Generic.IEnumerable<Specialitation> GetAllEntities()
        {
            return spetialitationService.GetAllEntities();
        }

        public Specialitation GetEntity(int id)
        {
            return spetialitationService.GetEntity(id);
        }

        public void UpdateEntity(Specialitation entity)
        {
            spetialitationService.UpdateEntity(entity);
        }
    }
}