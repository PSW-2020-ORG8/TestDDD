/***********************************************************************
 * Module:  HospitalitationRepository.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Repository.HospitalitationRepository
 ***********************************************************************/

using Backend.Repository.MySQL;
using Backend.Repository.MySQL.Stream;
using Model.Term;
using Repository.Csv;
using Repository.Csv.Converter;
using Repository.Csv.Stream;
using Repository.IDSequencer;
using System;
using System.Collections.Generic;

namespace Repository.ExaminationSurgeryRepository
{
    public class HospitalitationRepository : MySQLRepository<Hospitalitation, int>, IHospitalitationRepository
    {
        private const string HOSPITALITATION_FILE = "../../Resources/Data/hospitalitations.csv";
        private static HospitalitationRepository instance;

        public static HospitalitationRepository Instance()
        {
            if (instance == null)
            {
                instance = new HospitalitationRepository(new MySQLStream<Hospitalitation>(), new IntSequencer());
            }
            return instance;
        }

        public HospitalitationRepository(IMySQLStream<Hospitalitation> stream, ISequencer<int> sequencer)
            : base(stream, sequencer)
        {
        }

        public List<Hospitalitation> GetAllHospitalitationsByRoom(Room room)
        {
            List<Hospitalitation> hospitalitations = new List<Hospitalitation>();
            foreach(Hospitalitation hospitalitation in GetAllEntities())
                if(hospitalitation.Room.RoomId == room.RoomId)
                    hospitalitations.Add(hospitalitation);
            return hospitalitations;
        }

        public List<Hospitalitation> GetByDate(DateTime date)
        {
            List<Hospitalitation> hospitalitations = new List<Hospitalitation>();
            foreach (Hospitalitation hospitalitation in GetAllEntities())
                if (hospitalitation.FromDateTime == date)
                    hospitalitations.Add(hospitalitation);
            return hospitalitations;
        }
    }
}