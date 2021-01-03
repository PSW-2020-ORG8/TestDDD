using HospitalMap.WPF.ModelWPF;
using Model.Term;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalMap.WPF.Converter
{
    public class WorkTimeRoomConverter : AbstractConverter
    {
        public static RoomWorkTime ConvertRoomToRoomWorkTime(Room room)
        {
            return new RoomWorkTime
            {
                IdOfRoomInMySQLDataBase = room.Id,
                IdOfRoom = room.IdRoomClinic,
                TypeOfRoomId = room.TypeOfRoomId,
                NameOfRoom = room.RoomId,
                NameOfClinic = room.NameOfClinic,
                NumberOfFloor = room.NumberOfFloor,
                FromDateTime = room.StartWorkTime,
                ToDateTime = room.EndWorkTime

            };
        }

        public static IList<RoomWorkTime> ConvertRoomToRoomWorkTime(IList<Room> rooms)
            => ConvertEntityListToViewList(rooms, ConvertRoomToRoomWorkTime);

    }
}
