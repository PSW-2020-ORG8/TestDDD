using Backend.Repository.MySQL;
using Backend.Repository.MySQL.Stream;
using Model.AllActors;
using Model.Patient;
using Repository.IDSequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository.UsersRepository
{
    public class SecretaryRepository : MySQLRepository<Secretary, int>, ISecretaryRepository
    {
        private static SecretaryRepository instance;

        public static SecretaryRepository Instance()
        {
            if (instance == null)
            {
                instance = new SecretaryRepository(new MySQLStream<Secretary>(), new IntSequencer());
            }
            return instance;
        }

        public SecretaryRepository(IMySQLStream<Secretary> stream, ISequencer<int> sequencer)
            : base(stream, sequencer)
        {
        }
    }
}
