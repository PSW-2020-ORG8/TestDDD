using Model.AllActors;
using Model.Doctor;
using System.Collections.Generic;

namespace UserMicroservice.Repository
{
    public interface IUserRepository : IRepository<User, int>
    {
        List<Doctor> GetAllDoctors();

        List<Patient> GetAllPatients();

        List<Secretary> GetAllSecretaries();

        List<Manager> GetAllManagers();

        User GetUserByUsername(string username);

        List<Doctor> GetDoctorBySpecialitation(Specialitation specialitation);

        User GetUserByJMBG(string jmbg);

    }
}
