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
    public class SearchTests
    {
        [Fact]
        public void Search_doctors_rooms()
        {
            RoomService roomService = new RoomService(CreateRoomrStubRepository());

            List<Room> result = roomService.SearchDoctorsRooms("office");

            Assert.NotNull(result);
        }


        [Fact]
        public void Search_doctors_rooms_count()
        {
            RoomService roomService = new RoomService(CreateRoomrStubRepository());

            List<Room> result = roomService.SearchDoctorsRooms("office");

            Assert.Equal(2,result.Count);
        }




        [Fact]
        public void Search_patients_rooms()
        {
            RoomService roomService = new RoomService(CreateRoomrStubRepository());

            List<Room> result = roomService.SearchPatientsRooms("Room");

            Assert.NotNull(result);
        }


        [Fact]
        public void Search_patients_rooms_count()
        {
            RoomService roomService = new RoomService(CreateRoomrStubRepository());

            List<Room> result = roomService.SearchPatientsRooms("Room");

            Assert.Equal(3, result.Count);
        }


        public void Search_another_rooms()
        {
            RoomService roomService = new RoomService(CreateRoomrStubRepository());

            List<Room> result = roomService.SearchAnotherRooms("Pharmacy");

            Assert.NotNull(result);
        }


        [Fact]
        public void Search_another_rooms_count()
        {
            RoomService roomService = new RoomService(CreateRoomrStubRepository());

            List<Room> result = roomService.SearchAnotherRooms("Pharmacy");

            Assert.Equal(2, result.Count);
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
            rooms.Add(new Room { Id = 7, RoomId = "Pharmacy", TypeOfRoomId = 4, Equipment = new List<InventaryRoom>(), DoctordId = 1, IdRoomClinic = "PhA", NameOfClinic = "A", NumberOfFloor = "0", BedCapacity = "", AvailableBeds = "", OccupiedBeds = "", StartWorkTime = "00", EndWorkTime = "24" });
            rooms.Add(new Room { Id = 8, RoomId = "Pharmacy", TypeOfRoomId = 4, Equipment = new List<InventaryRoom>(), DoctordId = 2, IdRoomClinic = "PhB", NameOfClinic = "B", NumberOfFloor = "", BedCapacity = "", AvailableBeds = "", OccupiedBeds = "", StartWorkTime = "00", EndWorkTime = "24" });



            stubRepository.Setup(roomRepository => roomRepository.GetAllEntities()).Returns(rooms);
            return stubRepository.Object;
        }
    }
}
