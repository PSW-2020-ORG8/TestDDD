using Backend.Repository.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentMicroservice.Repository.MySQL.Stream
{
    public class MySQLStream<E> : IMySQLStream<E>
        where E : class
    {
        private readonly HealthClinicDbContext dbContext;

        public MySQLStream()
        {
            this.dbContext = new HealthClinicDbContext();
        }

        public void Add(E entity)
        {
            dbContext.Set<E>().Add(entity);
        }

        public IEnumerable<E> ReadAll()
        {
            return dbContext.Set<E>();
        }

        public void SaveAll()
        {
            dbContext.SaveChanges();
        }
    }
}
