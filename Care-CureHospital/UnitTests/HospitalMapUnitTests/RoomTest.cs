using Model.Manager;
using Model.Term;
using Moq;
using Repository.RoomsRepository;
using Service.RoomsServices;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.HospitalMapUnitTests
{
    public class RoomTest
    {
        [Fact]
        public void Get_room_by_name()
        {
            RoomService roomService = new RoomService(CreateRoomrStubRepository());

           Room result = roomService.GetRoomByRoomId("Room 1");

            Assert.NotNull(result);
        }

        [Fact]
        public void Get_room_by_id()
        {
            RoomService roomService = new RoomService(CreateRoomrStubRepository());

            Room result = roomService.GetEntityByHospitalId("R1");

            Assert.NotNull(result);
        }

        [Fact]
        public void Get_all_rooms()
        {
            RoomService roomService = new RoomService(CreateRoomrStubRepository());

            List<Room> result = (List<Room>)roomService.GetAllEntities();

            Assert.NotEmpty(result);
        }

        [Fact]
        public void Get_all_rooms_by_type()
        {
            RoomService roomService = new RoomService(CreateRoomrStubRepository());

            List<Room> result = (List<Room>)roomService.GetAllEntitiesByType(3);

            Assert.Equal(3, result.Count);
        }


        [Fact]
        public void Room_witd_roomId_exists()
        {
            RoomService roomService = new RoomService(CreateRoomrStubRepository());

            bool result = roomService.RoomWithRoomIDExist("Doctor office 3");

            Assert.Equal(true, result);
        }




        private static IRoomRepository CreateRoomrStubRepository()
        {
            var stubRepository = new Mock<IRoomRepository>();

            List<Room> rooms = new List<Room>();
            rooms.Add(new Room { Id = 1, RoomId = "Room 1", TypeOfRoomId = 3, Equipment = new List<InventaryRoom>(), DoctordId = 1, IdRoomClinic = "R1", NameOfClinic = "A", NumberOfFloor = "1", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" });
            rooms.Add(new Room { Id = 2, RoomId = "Room 2", TypeOfRoomId = 3, Equipment = new List<InventaryRoom>(), DoctordId = 1, IdRoomClinic = "R2", NameOfClinic = "A", NumberOfFloor = "1", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" });
            rooms.Add(new Room { Id = 3, RoomId = "Room 3", TypeOfRoomId = 3, Equipment = new List<InventaryRoom>(), DoctordId = 1, IdRoomClinic = "R3", NameOfClinic = "A", NumberOfFloor = "1", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" });
            rooms.Add(new Room { Id = 4, RoomId = "Doctor office 3", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 1, IdRoomClinic = "Dr3", NameOfClinic = "A", NumberOfFloor = "1", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "08", EndWorkTime = "16" });
            rooms.Add(new Room { Id = 5, RoomId = "Doctor office 4", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "Dr4", NameOfClinic = "A", NumberOfFloor = "1", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "08", EndWorkTime = "16" });
            rooms.Add(new Room { Id = 6, RoomId = "Surgery room 3", TypeOfRoomId = 1, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "Sr3A", NameOfClinic = "A", NumberOfFloor = "0", BedCapacity = "10", AvailableBeds = "5", OccupiedBeds = "5", StartWorkTime = "00", EndWorkTime = "24" });

            stubRepository.Setup(roomRepository => roomRepository.GetAllEntities()).Returns(rooms);
            return stubRepository.Object;
        }
    }
}
