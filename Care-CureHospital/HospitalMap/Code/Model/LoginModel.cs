using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalMap.Code.Model
{
    class LoginModel
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public String Role { get; set; }


        public LoginModel()
        {
        }

        public LoginModel(string username, string password, string role)
        {
            this.Username = username;
            this.Password = password;
            this.Role = role;
        }
    }
}
