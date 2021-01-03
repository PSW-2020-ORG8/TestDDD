/***********************************************************************
 * Module:  RoomService.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Service.RoomService
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Model.Term;
using Model.Manager;
using Repository.RoomsRepository;

namespace Service.RoomsServices
{
    public class RoomService : IService<Room, int>
    {
        public IRoomRepository roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        public List<Room> GetAllRoomForMedicalExamination()
        {
            List<Room> medicalExaminationRooms = new List<Room>();
            foreach (Room room in roomRepository.GetAllEntities())
                if (room.TypeOfRoom.NameOfType.Equals("Soba za preglede"))
                    medicalExaminationRooms.Add(room);
            return medicalExaminationRooms;
        }

        public List<Room> GetAllRoomForHospitalitation()
        {
            List<Room> hospitalitationRooms = new List<Room>();
            foreach (Room room in GetAllEntities())
                if (room.TypeOfRoom.NameOfType.Equals("Bolnička soba"))
                    hospitalitationRooms.Add(room);
            return hospitalitationRooms;
        }

        public List<Room> GetAllRoomForSurgery()
        {
            List<Room> surgeryRooms = new List<Room>();
            foreach (Room room in GetAllEntities())
                if (room.TypeOfRoom.NameOfType.Equals("Soba za operacije"))
                    surgeryRooms.Add(room);
            return surgeryRooms;
        }

        public bool RoomWithRoomIDExist(String roomID)
        {
            foreach (Room room in roomRepository.GetAllEntities())
                if (room.RoomId.Equals(roomID))
                    return true;
            return false;
        }

        public void DetermineTypeOfRoom(TypeOfRoom typeOfRoom, String roomID)
        {
            foreach (Room room in roomRepository.GetAllEntities())
                if (room.RoomId.Equals(roomID))
                {
                    room.TypeOfRoom = typeOfRoom;
                    break;
                }
        }

        public void AddEquipmentInRoom(InventaryRoom equipment, String roomID)
        {
            foreach (Room room in roomRepository.GetAllEntities())
                if (room.RoomId == roomID)
                    room.Equipment.Add(equipment);
        }

        public List<InventaryRoom> GetEquipmentForRoom(Room room)
        {
            foreach (Room oneRoom in roomRepository.GetAllEntities())
                if (oneRoom.RoomId == room.RoomId)
                    return oneRoom.Equipment;
            return null;
        }

        public Room GetRoomByRoomId(String roomID)
        {
            foreach (Room oneRoom in roomRepository.GetAllEntities())
                if (oneRoom.RoomId == roomID)
                    return oneRoom;
            return null;
        }

        public DateTime GetLastTermForRoom(Room room)
        {
            return room.ToDateTime;
        }

        public Room GetEntity(int id)
        {
            return roomRepository.GetEntity(id);
        }

        public Room GetEntityByHospitalId(string id)
        {
            foreach (Room currentRoom in roomRepository.GetAllEntities())
            {
                if (currentRoom.IdRoomClinic.Equals(id.ToString()))
                {
                    return currentRoom;
                }
            }
            return null;
        }

        public IEnumerable<Room> GetAllEntities()
        {
            return roomRepository.GetAllEntities();
        }



        public List<Room> GetAllEntitiesByType(int type)
        {
            List<Room> room = new List<Room>();
            foreach (Room currentRoom in roomRepository.GetAllEntities())
            {
                if (currentRoom.TypeOfRoomId==type)
                {
                    room.Add(currentRoom);
                }
            }
            return room;

        }

        public List<Room> SearchPatientsRooms(string nameOfRoom)
        {
            List<Room> searchedRooms = new List<Room>();

            foreach (Room currentRoom in roomRepository.GetAllEntities())
            {
                if (currentRoom.RoomId.Contains(nameOfRoom) && currentRoom.TypeOfRoomId==3)
                {
                    searchedRooms.Add(currentRoom);
                }


            }

            return searchedRooms;
        }

        public List<Room> SearchDoctorsRooms(string nameOfRoom)
        {
            List<Room> searchedRooms = new List<Room>();

            foreach (Room currentRoom in roomRepository.GetAllEntities())
            {
                if (currentRoom.RoomId.Contains(nameOfRoom) && currentRoom.TypeOfRoomId == 1)
                {
                    searchedRooms.Add(currentRoom);
                }


            }

            return searchedRooms;
        }

        public List<Room> SearchAnotherRooms(string nameOfRoom)
        {
            List<Room> searchedRooms = new List<Room>();

            foreach (Room currentRoom in roomRepository.GetAllEntities())
            {
                if (currentRoom.RoomId.Contains(nameOfRoom) && currentRoom.TypeOfRoomId == 4)
                {
                    searchedRooms.Add(currentRoom);
                }


            }

            return searchedRooms;
        }

        public Room AddEntity(Room entity)
        {
            return roomRepository.AddEntity(entity);
        }

        public void UpdateEntity(Room entity)
        {
            roomRepository.UpdateEntity(entity);
        }

        public void DeleteEntity(Room entity)
        {
            roomRepository.DeleteEntity(entity);
        }

        public Room GetFirstRoom(List<Room> rooms)
        {
            foreach (Room room in rooms)
                return room;
            return null;
        }


    }
}