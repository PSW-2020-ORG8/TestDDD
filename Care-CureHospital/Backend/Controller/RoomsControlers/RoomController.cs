/***********************************************************************
 * Module:  RoomService.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Service.RoomService
 ***********************************************************************/

using Model.Term;
using Model.Manager;
using Service.RoomsServices;
using System;
using System.Collections.Generic;

namespace Controller.RoomsControlers
{
    public class RoomController : IController<Room, int>
    {
        public RoomService roomService;

        public RoomController(RoomService roomService)
        {
            this.roomService = roomService;
        }

        public bool RoomWithRoomIDExist(String roomID)
        {
            return roomService.RoomWithRoomIDExist(roomID);
        }

        public void DetermineTypeOfRoom(TypeOfRoom typeOfRoom, String roomID)
        {
            roomService.DetermineTypeOfRoom(typeOfRoom, roomID);
        }

        public void AddEquipmentInRoom(InventaryRoom equipment, String roomID)
        {
            roomService.AddEquipmentInRoom(equipment, roomID);
        }

        private List<InventaryRoom> GetEquipmentForRoom(Room room)
        {
            return roomService.GetEquipmentForRoom(room);
        }

        public List<Room> GetAllRoomForMedicalExamination()
        {
            return roomService.GetAllRoomForMedicalExamination();
        }
        public Room GetRoomByRoomID(String roomID)
        {
            return roomService.GetRoomByRoomId(roomID);
        }

        public List<Room> GetAllRoomForHospitalitation()
        {
            return roomService.GetAllRoomForHospitalitation();
        }

        public List<Room> GetAllRoomForSurgery()
        {
            return roomService.GetAllRoomForSurgery();
        }

        public DateTime GetLastTermForRoom(Room room)
        {
            return roomService.GetLastTermForRoom(room);
        }

        public Room GetEntity(int id)
        {
            return roomService.GetEntity(id);
        }

        public IEnumerable<Room> GetAllEntities()
        {
            return roomService.GetAllEntities();
        }

        public Room AddEntity(Room entity)
        {
            return roomService.AddEntity(entity);
        }

        public void UpdateEntity(Room entity)
        {
            roomService.UpdateEntity(entity);
        }

        public void DeleteEntity(Room entity)
        {
            roomService.DeleteEntity(entity);
        }

        public Room GetFirstRoom(List<Room> rooms)
        {
            return roomService.GetFirstRoom(rooms);
        }

    }
}