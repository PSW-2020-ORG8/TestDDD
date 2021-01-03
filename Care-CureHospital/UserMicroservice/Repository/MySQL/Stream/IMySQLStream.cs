using System.Collections.Generic;

namespace UserMicroservice.Repository.MySQL.Stream
{
    public interface IMySQLStream<E>
    {
        void SaveAll();

        IEnumerable<E> ReadAll();

        void Add(E entity);
    }
}
