using HospitalMap.WPF.ModelWPF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace HospitalMap.Code.Repository.RoomInformatioRepository
{
    public class RoomWorkTimeRepository
    {
        private const String _path = @"./../../../Code/Resources/RoomTimesInformation.txt";

        private static RoomWorkTimeRepository _instance = null;

        public static RoomWorkTimeRepository GetInstance()
        {
            if (_instance == null)
            {
                _instance = new RoomWorkTimeRepository();
            }
            return _instance;
        }

        public ObservableCollection<RoomWorkTime> AllWorkTime
        {
            get;
            set;

        }

        public RoomWorkTimeRepository()
        {

            /*
            AllWorkTime = new ObservableCollection<WorkTimeViewModel>();
            AllWorkTime.Add(new WorkTimeViewModel()
            {
                IdOfRoom="1",
                FromDateTime="00",
                ToDateTime="24"
                
                

            });

            saveAll(AllWorkTime);
            
            */

            AllWorkTime = GetAll();



        }

        public ObservableCollection<RoomWorkTime> GetAll()
        {
            String text = "";

            if (File.Exists(_path))
                text = File.ReadAllText(_path);

            return JsonConvert.DeserializeObject<ObservableCollection<RoomWorkTime>>(text);

        }

        public void SaveAll(ObservableCollection<RoomWorkTime> roomsWorkTime)
        {
            string json = JsonConvert.SerializeObject(roomsWorkTime, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(_path, json);
        }


        public void Edit(RoomWorkTime workTime)
        {
            AllWorkTime = GetAll();
            foreach (RoomWorkTime currnetWorkTime in AllWorkTime)
            {
                if (currnetWorkTime.IdOfRoom.Equals(workTime.IdOfRoom.ToString()) )
                {
                    currnetWorkTime.NameOfClinic = workTime.NameOfClinic;
                    currnetWorkTime.NumberOfFloor = workTime.NumberOfFloor;
                    currnetWorkTime.FromDateTime = workTime.FromDateTime;
                    currnetWorkTime.ToDateTime = workTime.ToDateTime;
                   
                }
            }
            SaveAll(AllWorkTime);
        }





        public RoomWorkTime GetById(string roomId)
        {
            foreach (RoomWorkTime currentRoom in GetAll())
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
