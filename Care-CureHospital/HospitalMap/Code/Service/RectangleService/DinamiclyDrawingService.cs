using HospitalMap.Code.Model.Canvas;
using HospitalMap.Code.Repository.RectangleRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace HospitalMap.Code.Service.RectangleService
{
    public class DinamiclyDrawingService
    {
        public ObservableCollection<Rectangles> Rectangle
        {
            get;
            set;

        }

        public ObservableCollection<Rectangles> GroundFloor1
        {
            get;
            set;

        }

        public ObservableCollection<Rectangles> GroundFloor2
        {
            get;
            set;

        }

        public ObservableCollection<Rectangles> FirstFloor
        {
            get;
            set;

        }

        public DinamiclyDrawingService()
        {
            Rectangle = new ObservableCollection<Rectangles>();
            Rectangle = DinamiclyDrawingRepository.GetInstance().GetAllRectangles();
            GroundFloor1 = new ObservableCollection<Rectangles>();
            GroundFloor1 = GroundFloor1Repository.GetInstance().GetAllRectangles();
            GroundFloor2 = new ObservableCollection<Rectangles>();
            GroundFloor2 = GroundFloor2Repository.GetInstance().GetAllRectangles();
            FirstFloor = new ObservableCollection<Rectangles>();
            FirstFloor = FirstFloorRepository.GetInstance().GetAllRectangles();
        }

    }
}
