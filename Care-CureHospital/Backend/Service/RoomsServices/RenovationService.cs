/***********************************************************************
 * Module:  RenovationService.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Service.RenovationService
 ***********************************************************************/

using Model.Manager;
using Model.Term;
using Repository.RoomsRepository;
using System;
using System.Collections.Generic;

namespace Service.RoomsServices
{
    public class RenovationService : IService<Renovation, int>
    {
        public IRenovationRepository renovationRepository;
        public RoomService roomService;

        public RenovationService(IRenovationRepository renovationRepository, RoomService roomService)
        {
            this.renovationRepository = renovationRepository;
            this.roomService = roomService;
        }

        public Room[] SeparateOnTwoParts(Room roomForRenovation) 
        {
            Room[] rooms = new Room[2];
            rooms[0] = roomForRenovation;
            rooms[1] = new Room(roomForRenovation.RoomId.Replace("a", "b"),
                new TypeOfRoom(roomForRenovation.TypeOfRoom.ToString()), new List<InventaryRoom>());
            return rooms;
        }

        public void ConnectTwoParts(Room firstPartOfRoom, Room secondPartOfRoom) 
        {
            List<InventaryRoom> equipmentForRelocate = secondPartOfRoom.Equipment;
            foreach (InventaryRoom equipment in equipmentForRelocate)
                roomService.AddEquipmentInRoom(equipment, firstPartOfRoom.RoomId);
            roomService.DeleteEntity(secondPartOfRoom);
        }

        public bool ExistRenovation(Room roomForRenovation)  
        {
            foreach (Renovation oneRenovation in renovationRepository.GetAllEntities())
                if (oneRenovation.Room.GetId() == roomForRenovation.GetId())
                    return true;
            return false;
        }

        public bool IsRoomFreeForRenovation(Room room, DateTime term)
        {
            if (room.ToDateTime > term)
                return false;
            return true;
        }

        public Room FindSecondPart(Room room)
        {
            foreach(Room oneRoom in roomService.GetAllEntities())
                if (room.RoomId.Replace("a", "b").Equals(oneRoom.RoomId))
                    return room;
            return null;
        }

        public Renovation GetEntity(int id)
        {
            return renovationRepository.GetEntity(id);
        }

        public IEnumerable<Renovation> GetAllEntities()
        {
            return renovationRepository.GetAllEntities();
        }

        public Renovation AddEntity(Renovation entity)
        {
            return renovationRepository.AddEntity(entity);
        }

        public void UpdateEntity(Renovation entity)
        {
            renovationRepository.UpdateEntity(entity);
        }

        public void DeleteEntity(Renovation entity)
        {
            renovationRepository.DeleteEntity(entity);
        }

    }
}