using HospitalMap.Code.Model;
using HospitalMap.Code.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HospitalMap.Code.Service
{
    class LoginService
    {
        public LoginRepository LoginRepository;

        public LoginService(LoginRepository loginRepository)
        {
            this.LoginRepository = loginRepository;
        }

        public LoginService()
        {
        }

        public ObservableCollection<LoginModel> GetAllLogins()
        {
            ObservableCollection<LoginModel> logins = new ObservableCollection<LoginModel>();


            logins = LoginRepository.GetInstance().GetAllLogins();
            
            
            return logins;
        }
    }
}
