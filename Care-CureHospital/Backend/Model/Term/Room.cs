/***********************************************************************
 * Module:  Soba.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Term.Soba
 ***********************************************************************/

using Model.Manager;
using HealthClinic.Repository;
using System;
using System.Collections.Generic;


namespace Model.Term
{
    public class Room : Term, IIdentifiable<int>
    {
        public int Id { get; set; }
        public string RoomId { get; set; }
        public int TypeOfRoomId { get; set; }
        public virtual TypeOfRoom TypeOfRoom { get; set; }
        public virtual List<InventaryRoom> Equipment { get; set; }

        public int DoctordId { get; set; }
        public virtual Model.AllActors.Doctor Doctor { get; set; }

        public string IdRoomClinic { get; set; }

        public string NameOfClinic { get; set; }
        public string NumberOfFloor { get; set; }
        public string BedCapacity { get; set; }
        public string AvailableBeds { get; set; }
        public string OccupiedBeds { get; set; }

        public string StartWorkTime { get; set; }
        public string EndWorkTime { get; set; }

        public Room(int id, string roomId, int typeOfRoomId, List<InventaryRoom> equipment, int doctordId, string idRoomClinic, string nameOfClinic, string numberOfFloor, string bedCapacity, string availableBeds, string occupiedBeds, string startWorkTime, string endWorkTime) : this(id, roomId, typeOfRoomId, equipment)
        {
            DoctordId = doctordId;
            IdRoomClinic = idRoomClinic;
            NameOfClinic = nameOfClinic;
            NumberOfFloor = numberOfFloor;
            BedCapacity = bedCapacity;
            AvailableBeds = availableBeds;
            OccupiedBeds = occupiedBeds;
            StartWorkTime = startWorkTime;
            EndWorkTime = endWorkTime;
        }

        public Room(int id)
        {
            Id = id;
        }

        public Room()
        {
        }

        public Room(int id, string roomID, TypeOfRoom typeOfRoom, DateTime fromDateTime, DateTime toDateTime, List<InventaryRoom> equipment) : base(fromDateTime, toDateTime)
        {
            RoomId = roomID;
            Id = id;            
            TypeOfRoom = typeOfRoom;
            Equipment = equipment;         
        }

        public Room(string roomID, TypeOfRoom typeOfRoom, List<InventaryRoom> equipment)
        {
            RoomId = roomID;
            TypeOfRoom = typeOfRoom;
            Equipment = equipment;
        }

        public Room(int id, string roomID, int typeOfRoomID, List<InventaryRoom> equipment) : this(id)
        {
            RoomId = roomID;
            TypeOfRoomId = typeOfRoomID;
            Equipment = equipment;
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}