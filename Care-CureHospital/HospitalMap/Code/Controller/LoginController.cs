using HospitalMap.Code.Model;
using HospitalMap.Code.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HospitalMap.Code.Controller
{
    class LoginController
    {
        public LoginService LoginService;

        public LoginController()
        {

            this.LoginService = new LoginService();

        }

        public ObservableCollection<LoginModel> GetAllLogins()
        {
            return LoginService.GetAllLogins();
        }
    }
}
