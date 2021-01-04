using System;
using System.Collections.Generic;
using UserMicroservice.Domain;

namespace UserMicroservice.Service
{
    public interface IUserService : IService<User, int>
    {
        public User Authenticate(string username, string password, byte[] secretKey);
        public IEnumerable<User> GetAllPatientsAndSystemAdministrators();
        public String FindPasswordByUsername(String username);
        public bool DoesUsernameExist(String username);
        public List<Doctor> GetAllDoctors();
        public List<Patient> GetAllPatients();
        public List<Doctor> GetDoctorBySpecialitation(Specialitation specialitation);
        public User GetUserByUsername(String username);
    }
}
