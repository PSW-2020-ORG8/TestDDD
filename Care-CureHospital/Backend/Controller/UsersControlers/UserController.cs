/***********************************************************************
 * Module:  UserService.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Service.UserService
 ***********************************************************************/

using Model.AllActors;
using Model.Doctor;
using Service.UsersServices;
using System;
using System.Collections.Generic;

namespace Controller.UsersControlers
{
    public class UserController : IController<User, int>
    {
        public UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        public User Login(String username, String password)
        {
            return userService.Login(username, password);
        }

        public String FindPasswordByUsername(String username)
        {
            return userService.FindPasswordByUsername(username);
        }

        public bool IsPasswordValid(String password)
        {
            return userService.IsPasswordValid(password);
        }

        public bool DoesJmbgExsist(String jmbg)
        {
            return userService.DoesJmbgExsist(jmbg);
        }

        public List<Doctor> GetDoctorBySpecialitation(Specialitation specialitation)
        {
            return userService.GetDoctorBySpecialitation(specialitation);
        }

        public User GetUserByUsername(String username)
        {
            return userService.GetUserByUsername(username);
        }

        public bool IsUsernameExist(String username)
        {
            return userService.DoesUsernameExist(username);
        }

        public User GetUserByJMBG(String jmbg)
        {
            return userService.GetUserByJMBG(jmbg);
        }

        public List<Doctor> GetAllDoctors()
        {
            return userService.GetAllDoctors();
        }

        public List<Patient> GetAllPatients()
        {
            return userService.GetAllPatients();
        }

        public List<Secretary> GetAllSecretaries()
        {
            return userService.GetAllSecretaries();
        }

        public List<Manager> GetAllManagers()
        {
            return userService.GetAllManagers();
        }

        public User GetEntity(int id)
        {
            return userService.GetEntity(id);
        }

        public IEnumerable<User> GetAllEntities()
        {
            return userService.GetAllEntities();
        }

        public User AddEntity(User entity)
        {
            return userService.AddEntity(entity);
        }

        public void UpdateEntity(User entity)
        {
            userService.UpdateEntity(entity);
        }

        public void DeleteEntity(User entity)
        {
            userService.DeleteEntity(entity);
        }

    }
}