using HospitalMap.WPF.ModelWPF;
using Model.Term;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalMap.WPF.Converter
{
    class DoctorRoomConverter : AbstractConverter
    {

        public static DoctorRoomView ConvertRoomToDoctorRoomView(Room room)
        {
            return new DoctorRoomView
            {
                IdOfRoomInMySQLDataBase = room.Id,
                IdOfRoom = room.IdRoomClinic,
                TypeOfRoomId=room.TypeOfRoomId,
                NameOfRoom = room.RoomId,
                NameOfClinic = room.NameOfClinic,
                NumberOfFloor = room.NumberOfFloor,
                FromDateTime=room.StartWorkTime,
                ToDateTime=room.EndWorkTime
                
            };
        }

        public static IList<DoctorRoomView> ConvertRoomToDoctorRoomView(IList<Room> rooms)
            => ConvertEntityListToViewList(rooms, ConvertRoomToDoctorRoomView);


    }
}
