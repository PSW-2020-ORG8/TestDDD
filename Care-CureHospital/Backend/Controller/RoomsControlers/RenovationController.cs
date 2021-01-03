/***********************************************************************
 * Module:  RenovationService.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Service.RenovationService
 ***********************************************************************/

using Model.Term;
using Service.RoomsServices;
using System;
using System.Collections.Generic;

namespace Controller.RoomsControlers
{
    public class RenovationController : IController<Renovation, int>
    {
        public RenovationService renovationService;

        public RenovationController(RenovationService renovationService)
        {
            this.renovationService = renovationService;
        }

        private bool ExistRenovation(Room roomForRenovation)
        {
            return renovationService.ExistRenovation(roomForRenovation);
        }

        public Room[] SeparateOnTwoParts(Room roomForRenovation)
        {
            return renovationService.SeparateOnTwoParts(roomForRenovation);
        }

        public void ConnectTwoParts(Room firstPartOfRoom, Room secondPartOfRoom)
        {
            renovationService.ConnectTwoParts(firstPartOfRoom, secondPartOfRoom);
        }

        public bool IsRoomFreeForRenovation(Room room, DateTime term)
        {
            return renovationService.IsRoomFreeForRenovation(room, term);
        }

        public Room FindSecondPart(Room room)
        {
            return renovationService.FindSecondPart(room);
        }

        public Renovation GetEntity(int id)
        {
            return renovationService.GetEntity(id);
        }

        public IEnumerable<Renovation> GetAllEntities()
        {
            return renovationService.GetAllEntities();
        }

        public Renovation AddEntity(Renovation entity)
        {
            return renovationService.AddEntity(entity);
        }

        public void UpdateEntity(Renovation entity)
        {
            renovationService.UpdateEntity(entity);
        }

        public void DeleteEntity(Renovation entity)
        {
            renovationService.DeleteEntity(entity);
        }

    }
}