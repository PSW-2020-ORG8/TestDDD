using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using UserMicroservice.Domain;
using UserMicroservice.Repository;

namespace UserMicroservice.Service
{
    public class UserService : IUserService
    {
        public IUserRepository userRepository;
        public IPatientService patientService;
        public ISystemAdministratorService systemAdministratorService;

        public UserService(IUserRepository userRepository, PatientService patientService, SystemAdministratorService systemAdministratorService)
        {
            this.userRepository = userRepository;
            this.patientService = patientService;
            this.systemAdministratorService = systemAdministratorService;
        }

        public User Authenticate(string username, string password, byte[] secretKey)
        {
            var user = GetAllPatientsAndSystemAdministrators().SingleOrDefault(user => user.Username == username && user.Password == password);

            if (user == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = secretKey;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim("UserRole", user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user;
        }

        public IEnumerable<User> GetAllPatientsAndSystemAdministrators()
        {
            List<User> users = new List<User>();
            users.AddRange(patientService.GetAllEntities());
            users.AddRange(systemAdministratorService.GetAllEntities());
            return users;
        }

        public String FindPasswordByUsername(String username)
        {
            foreach (User user in GetAllEntities())
                if (user.Username.Equals(username))
                    return user.Password;
            return "";
        }

        public bool DoesUsernameExist(String username)
        {
            foreach (User user in GetAllEntities())
                if (user.Username.Equals(username))
                    return true;

            return false;
        }

        public List<Doctor> GetAllDoctors()
        {
            return userRepository.GetAllDoctors();
        }

        public List<Patient> GetAllPatients()
        {
            return userRepository.GetAllPatients();
        }

        public List<Doctor> GetDoctorBySpecialitation(Specialitation specialitation)
        {
            return userRepository.GetDoctorBySpecialitation(specialitation);
        }

        public User GetUserByUsername(String username)
        {
            return userRepository.GetUserByUsername(username);
        }

        public User GetEntity(int id)
        {
            return userRepository.GetEntity(id);
        }

        public IEnumerable<User> GetAllEntities()
        {
            return userRepository.GetAllEntities();
        }

        public User AddEntity(User entity)
        {
            return userRepository.AddEntity(entity);
        }

        public void UpdateEntity(User entity)
        {
            userRepository.UpdateEntity(entity);
        }

        public void DeleteEntity(User entity)
        {
            userRepository.DeleteEntity(entity);
        }
    }
}
