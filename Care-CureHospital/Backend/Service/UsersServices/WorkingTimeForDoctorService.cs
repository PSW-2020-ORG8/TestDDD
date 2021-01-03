/***********************************************************************
 * Module:  WorkingTimeForDoctorService.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Service.WorkingTimeForDoctorService
 ***********************************************************************/

using Model.Term;
using Model.AllActors;
using System;
using System.Collections.Generic;
using Repository.UsersRepository;

namespace Service.UsersServices
{
    public class WorkingTimeForDoctorService : IService<WorkingTimeForDoctor, int>
    {
        public IWorkingTimeForDoctorRepository workingTimeForDoctorRepository;

        public WorkingTimeForDoctorService(IWorkingTimeForDoctorRepository workingTimeForDoctorRepository)
        {
            this.workingTimeForDoctorRepository = workingTimeForDoctorRepository;
        }

        public WorkingTimeForDoctor GetWorkTimeForDoctorByDoctorAndDay(Doctor doctor, DayOfWeek day)
        {
            foreach (WorkingTimeForDoctor workingTime in workingTimeForDoctorRepository.GetAllEntities())
                if (workingTime.Doctor.Id == doctor.Id && workingTime.Day.ToString().Equals(day.ToString()))
                    return workingTime;
            return null;
        }

        public List<WorkingTimeForDoctor> GetWorkTimeForDoctor(Doctor doctor) 
        {
            List<WorkingTimeForDoctor> workingTimeForDoctor = new List<WorkingTimeForDoctor>();
            foreach (WorkingTimeForDoctor workingTime in workingTimeForDoctorRepository.GetAllEntities())
                if (workingTime.Doctor.GetId() == doctor.GetId())
                    workingTimeForDoctor.Add(workingTime);
            return workingTimeForDoctor;
        }

        public WorkingTimeForDoctor GetWorkTimeForDoctorByDay(DayOfWeek day)
        {
            foreach (WorkingTimeForDoctor workingTime in workingTimeForDoctorRepository.GetAllEntities())
                if (workingTime.Day.Equals(day))
                    return workingTime;
            return null;
        }

        public WorkingTimeForDoctor GetEntity(int id)
        {
            return workingTimeForDoctorRepository.GetEntity(id);
        }

        public IEnumerable<WorkingTimeForDoctor> GetAllEntities()
        {
            return workingTimeForDoctorRepository.GetAllEntities();
        }

        public WorkingTimeForDoctor AddEntity(WorkingTimeForDoctor entity)
        {
            return workingTimeForDoctorRepository.AddEntity(entity);
        }

        public void UpdateEntity(WorkingTimeForDoctor entity)
        {
            workingTimeForDoctorRepository.UpdateEntity(entity);
        }

        public void DeleteEntity(WorkingTimeForDoctor entity)
        {
            workingTimeForDoctorRepository.DeleteEntity(entity);
        }

    }
}