/***********************************************************************
 * Module:  WorkingTimeForDoctorRepository.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Repository.WorkingTimeForDoctorRepository
 ***********************************************************************/

using Backend.Repository.MySQL;
using Backend.Repository.MySQL.Stream;
using Model.AllActors;
using Model.Term;
using Repository.Csv;
using Repository.Csv.Converter;
using Repository.Csv.Stream;
using Repository.IDSequencer;
using System;
using System.Collections.Generic;

namespace Repository.UsersRepository
{
   public class WorkingTimeForDoctorRepository : MySQLRepository<WorkingTimeForDoctor,int>, IWorkingTimeForDoctorRepository
   {
        private const string WORKINGTIMEFORDOCTOR_FILE = "../../Resources/Data/workingtimefordoctor.csv";
        private static WorkingTimeForDoctorRepository instance;

        public static WorkingTimeForDoctorRepository Instance()
        {
            if (instance == null)
            {
                instance = new WorkingTimeForDoctorRepository(new MySQLStream<WorkingTimeForDoctor>(), new IntSequencer());
            }
            return instance;
        }

        public WorkingTimeForDoctorRepository(IMySQLStream<WorkingTimeForDoctor> stream, ISequencer<int> sequencer)
         : base(stream, sequencer)
        {
        }

        public List<WorkingTimeForDoctor> GetWorkTimeForDoctor(Doctor doctor)
        {
            List<WorkingTimeForDoctor> workingTimesForDoctor = new List<WorkingTimeForDoctor>();
            foreach (WorkingTimeForDoctor workingTimeForDoctor in GetAllEntities())
                if (workingTimeForDoctor.Doctor.GetId() == doctor.GetId())
                    workingTimesForDoctor.Add(workingTimeForDoctor);
            return workingTimesForDoctor;
        }
    }
}