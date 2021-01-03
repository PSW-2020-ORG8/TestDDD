using HospitalMap.Code.Model;
using HospitalMap.WPF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace HospitalMap.Code.Repository
{
    class LoginRepository
    {
        private const String _path = @"./../../../Code/Resources/login.txt";

        private static LoginRepository _instance = null;
        public static LoginRepository GetInstance()
        {
            if (_instance == null)
            {
                _instance = new LoginRepository();
            }
            return _instance;
        }

        public ObservableCollection<LoginModel> GetAllLogins()
        {
            String text = "";

            if (File.Exists(_path))
                text = File.ReadAllText(_path);

            return JsonConvert.DeserializeObject<ObservableCollection<LoginModel>>(text);
        }
    }
}
