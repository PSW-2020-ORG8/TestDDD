using Backend.Repository.MySQL;
using System.Collections.Generic;

namespace UserMicroservice.Repository.MySQL.Stream
{
    public class MySQLStream<E> : IMySQLStream<E>
    where E : class
    {
        private readonly HealthClinicDbContext dbContext;

        public MySQLStream()
        {
            dbContext = new HealthClinicDbContext();
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
