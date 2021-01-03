using HospitalMap.WPF.ModelWPF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace HospitalMap.Code.Repository.DoctorsRepository
{
    public class DoctorsRoomRepository
    {
        private const String _path = @"./../../../Code/Resources/DoctorsInformation.txt";

        private static DoctorsRoomRepository _instance = null;

        public static DoctorsRoomRepository GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DoctorsRoomRepository();
            }
            return _instance;
        }

        public ObservableCollection<DoctorRoomView> Doctors
        {
            get;
            set;

        }

        public DoctorsRoomRepository()
        {
            /*
            WorkTime wk = new WorkTime();
            wk.FromDateTime = "08";
            wk.ToDateTime = "16";

            Doctors = new ObservableCollection<DoctorRoomView>();
            Doctors.Add(new DoctorRoomView()
            {
                IdOfRoom="1",
                NameOfDoctor="Stefan",
                SurnameOfDoctor="Markovic",
                JmbgOfDoctor="12345678911",
                FromDateTime="08",
                ToDateTime="16"
                

            });

            saveAll(Doctors);
            */

            Doctors = GetAll();



        }

        public ObservableCollection<DoctorRoomView> GetAll()
        {
            String text = "";

            if (File.Exists(_path))
                text = File.ReadAllText(_path);

            return JsonConvert.DeserializeObject<ObservableCollection<DoctorRoomView>>(text);

        }

        public void SaveAll(ObservableCollection<DoctorRoomView> rooms)
        {
            string json = JsonConvert.SerializeObject(rooms, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(_path, json);
        }


        public void Edit(DoctorRoomView doctor)
        {
            Doctors = GetAll();
            foreach (DoctorRoomView currentDoctor in Doctors)
            {
                if (currentDoctor.IdOfRoom.Equals(doctor.IdOfRoom.ToString()) && currentDoctor.JmbgOfDoctor.Equals(doctor.JmbgOfDoctor))
                {
                    currentDoctor.FromDateTime = doctor.FromDateTime;
                    currentDoctor.ToDateTime = doctor.ToDateTime;
                    currentDoctor.NameOfDoctor = doctor.NameOfDoctor;
                    currentDoctor.SurnameOfDoctor = doctor.SurnameOfDoctor;
                }
            }
            SaveAll(Doctors);
        }


       


        public DoctorRoomView GetById(string roomId)
        {
            foreach (DoctorRoomView currentRoom in GetAll())
            {
                if (currentRoom.IdOfRoom.Equals(roomId.ToString()))
                {
                    return currentRoom;
                }
            }
            return new DoctorRoomView();
        }

        public DoctorRoomView GetByJmbg(string doctorJmbg)
        {
            foreach (DoctorRoomView currentRoom in GetAll())
            {
                if (currentRoom.JmbgOfDoctor.Equals(doctorJmbg.ToString()))
                {
                    return currentRoom;
                }
            }
            return null;
        }

    }
}
