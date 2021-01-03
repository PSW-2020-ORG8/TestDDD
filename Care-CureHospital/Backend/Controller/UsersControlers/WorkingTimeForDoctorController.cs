/***********************************************************************
 * Module:  WorkingTimeForDoctorService.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Service.WorkingTimeForDoctorService
 ***********************************************************************/

using Model.Term;
using Service.UsersServices;
using Model.AllActors;
using System;
using System.Collections.Generic;

namespace Controller.UsersControlers
{
    public class WorkingTimeForDoctorController : IController<WorkingTimeForDoctor, int>
    {
        public WorkingTimeForDoctorService workingTimeForDoctorService;

        public WorkingTimeForDoctorController(WorkingTimeForDoctorService workingTimeForDoctorService)
        {
            this.workingTimeForDoctorService = workingTimeForDoctorService;
        }

        public WorkingTimeForDoctor GetWorkTimeForDoctorByDoctorAndDay(Doctor doctor, DayOfWeek day)
        {
            return workingTimeForDoctorService.GetWorkTimeForDoctorByDoctorAndDay(doctor, day);
        }

        public List<WorkingTimeForDoctor> GetWorkTimeForDoctor(Doctor doctor)
        {
            return workingTimeForDoctorService.GetWorkTimeForDoctor(doctor);
        }

        public WorkingTimeForDoctor GetWorkTimeForDoctorByDay(DayOfWeek day)
        {
            return workingTimeForDoctorService.GetWorkTimeForDoctorByDay(day);
        }

        public WorkingTimeForDoctor GetEntity(int id)
        {
            return workingTimeForDoctorService.GetEntity(id);
        }

        public IEnumerable<WorkingTimeForDoctor> GetAllEntities()
        {
            return workingTimeForDoctorService.GetAllEntities();
        }

        public WorkingTimeForDoctor AddEntity(WorkingTimeForDoctor entity)
        {
            return workingTimeForDoctorService.AddEntity(entity);
        }

        public void UpdateEntity(WorkingTimeForDoctor entity)
        {
            workingTimeForDoctorService.UpdateEntity(entity);
        }

        public void DeleteEntity(WorkingTimeForDoctor entity)
        {
           workingTimeForDoctorService.DeleteEntity(entity);
        }

    }
}