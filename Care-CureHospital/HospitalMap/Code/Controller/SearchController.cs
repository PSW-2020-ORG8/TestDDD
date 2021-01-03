using HospitalMap.Code.Service;
using HospitalMap.WPF.ModelWPF;
using Model.Term;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HospitalMap.Code.Controller
{
    public class SearchController
    {
        


        public SearchController() { }


        public List<Room> SearchPatientsRooms(string nameOfRoom)
        {
            return Backend.App.Instance().RoomService.SearchPatientsRooms(nameOfRoom);
        }


        public List<Room> SearchDoctorsRooms(string nameOfRoom)
        {
            return Backend.App.Instance().RoomService.SearchDoctorsRooms(nameOfRoom);
        }


        public List<Room> SearchAnotherRooms(string nameOfRoom)
        {
            return Backend.App.Instance().RoomService.SearchAnotherRooms(nameOfRoom);
        }

    }
}
