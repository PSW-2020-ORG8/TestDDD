using HospitalMap.WPF.ModelWPF;
using Model.Term;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalMap.WPF.Converter
{
   public class PatientsRoomConverter : AbstractConverter
    {
        public static PatientsRoomVieW ConvertRoomToPatientsRoomView(Room room)
        {
            return new PatientsRoomVieW
            {
                IdOfRoomInMySQLDataBase = room.Id,
                IdOfRoom = room.IdRoomClinic,
                TypeOfRoomId = room.TypeOfRoomId,
                NameOfRoom = room.RoomId,
                NameOfClinic = room.NameOfClinic,
                NumberOfFloor = room.NumberOfFloor,
                BedCapacity = room.BedCapacity,
                AvailableBeds=room.AvailableBeds,
                OccupiedBeds=room.OccupiedBeds
            };
        }

        public static IList<PatientsRoomVieW> ConvertRoomToPatientsRoomView(IList<Room> rooms)
            => ConvertEntityListToViewList(rooms, ConvertRoomToPatientsRoomView);
    }
}
