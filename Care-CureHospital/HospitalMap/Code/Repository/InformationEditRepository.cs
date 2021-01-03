using HospitalMap.WPF.ModelWPF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace HospitalMap.Repository
{
    public class InformationEditRepository
    {
        private const String _path = @"./../../../Code/Resources/RoomsInformation.txt";

        private static InformationEditRepository _instance = null;

        public static InformationEditRepository GetInstance()
        {
            if (_instance == null)
            {
                _instance = new InformationEditRepository();
            }
            return _instance;
        }

        public ObservableCollection<PatientsRoomVieW> Rooms
        {
            get;
            set;

        }

        public InformationEditRepository()
        {
            
            Rooms = GetAll();



        }

        public ObservableCollection<PatientsRoomVieW> GetAll()
        {
            String text = "";

            if (File.Exists(_path))
                text = File.ReadAllText(_path);

            return JsonConvert.DeserializeObject<ObservableCollection<PatientsRoomVieW>>(text);

        }

        public void SaveAll(ObservableCollection<PatientsRoomVieW> rooms)
        {
            string json = JsonConvert.SerializeObject(rooms, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(_path, json);
        }


        public void Edit(PatientsRoomVieW room)
        {
            Rooms = GetAll();
            foreach(PatientsRoomVieW currentRoom in Rooms)
            {
                if (currentRoom.IdOfRoom.Equals(room.IdOfRoom.ToString())){
                    currentRoom.NameOfRoom = room.NameOfRoom;
                    currentRoom.NumberOfFloor = room.NumberOfFloor;
                    currentRoom.NameOfClinic = room.NameOfClinic;
                    currentRoom.BedCapacity = room.BedCapacity;
                    currentRoom.AvailableBeds = room.AvailableBeds;
                    currentRoom.OccupiedBeds = room.OccupiedBeds;
                }
            }
            SaveAll(Rooms);
        }


        public PatientsRoomVieW GetById(string roomId)
        {
            foreach (PatientsRoomVieW currentRoom in GetAll())
            {
                if (currentRoom.IdOfRoom.Equals(roomId.ToString()))
                {
                    return currentRoom;
                }
            }
            return null;
        }


    }
}
