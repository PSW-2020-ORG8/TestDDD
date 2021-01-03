// File:    SpecialitationRepository.cs
// Author:  Stefan
// Created: nedelja, 24. maj 2020. 18:26:58
// Purpose: Definition of Class SpecialitationRepository

using Backend.Repository.MySQL;
using Backend.Repository.MySQL.Stream;
using Model.Doctor;
using Repository.Csv;
using Repository.Csv.Stream;
using Repository.CSV.Converter;
using Repository.IDSequencer;
using System;

namespace Repository.UsersRepository
{
    public class SpecialitationRepository : MySQLRepository<Specialitation, int>, ISpecialitationRepository
    {
        private const string SPECIALITATION_FILE = "../../Resources/Data/specialitation.csv";
        private static SpecialitationRepository instance;

        public static SpecialitationRepository Instance()
        {
            if (instance == null)
            {
                instance = new SpecialitationRepository(new MySQLStream<Specialitation>(), new IntSequencer());
            }
            return instance;
        }

        public SpecialitationRepository(IMySQLStream<Specialitation> stream, ISequencer<int> sequencer)
         : base(stream, sequencer)
        {
        }

    }
}