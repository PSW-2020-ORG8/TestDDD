using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Media;

namespace HospitalMap.Code.Model.Canvas
{
    public class Rectangles : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _top;
        private int _left;
        private int _width;
        private int _height;
        private string _id;
        private Brush _paint;
        private Brush _background;
        private int _heightText;
        private string _text;
        private int _widthText;
        private int _topText;
        private int _leftText;



        public Brush Paint
        {
            get { return _paint; }
            set { _paint = value; OnPropertyChanged("Paint"); }

        }

        public string Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("Id"); }

        }

        public int Top
        {
            get { return _top; }
            set { _top = value; OnPropertyChanged("Top"); }

        }

        public int Left
        {
            get { return _left; }
            set { _left = value; OnPropertyChanged("Left"); }

        }



        public int Width
        {
            get { return _width; }
            set { _width = value; OnPropertyChanged("Width"); }

        }


        public int Height
        {
            get { return _height; }
            set { _height = value; OnPropertyChanged("Height"); }

        }

        public int TopText
        {
            get { return _topText; }
            set { _topText = value; OnPropertyChanged("TopText"); }

        }

        public int LeftText
        {
            get { return _leftText; }
            set { _leftText = value; OnPropertyChanged("LeftText"); }

        }

        public string Text
        {
            get { return _text; }
            set { _text = value; OnPropertyChanged("Width"); }

        }

        public int WidthText
        {
            get { return _widthText; }
            set { _widthText = value; OnPropertyChanged("Width"); }

        }


        public int HeightText
        {
            get { return _heightText; }
            set { _heightText = value; OnPropertyChanged("Height"); }

        }

        public Brush Background
        {
            get { return _background; }
            set { _background = value; OnPropertyChanged("Paint"); }

        }


        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
