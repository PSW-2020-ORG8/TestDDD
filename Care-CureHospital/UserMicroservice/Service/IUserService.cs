using Model.AllActors;
using System;
using System.Collections.Generic;

namespace UserMicroservice.Service
{
    public interface IUserService : IService<User, int>
    {
        public User Authenticate(string username, string password, byte[] secretKey);
        public IEnumerable<User> GetAllPatientsAndSystemAdministrators();
        public User Login(String username, String password);
        public String FindPasswordByUsername(String username);
        public bool IsPasswordValid(String password);
        public bool DoesUsernameExist(String username);
        public bool DoesJmbgExsist(String jmbg);
        public List<Doctor> GetAllDoctors();
        public List<Patient> GetAllPatients();
        public List<Secretary> GetAllSecretaries();
        public List<Manager> GetAllManagers();
        public List<Doctor> GetDoctorBySpecialitation(Model.Doctor.Specialitation specialitation);
        public User GetUserByUsername(String username);
        public User GetUserByJMBG(String jmbg);
    }
}
