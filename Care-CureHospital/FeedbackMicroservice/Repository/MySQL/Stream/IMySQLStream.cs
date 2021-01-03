using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Repository.MySQL.Stream
{
    public interface IMySQLStream<E>
    {
        void SaveAll();

        IEnumerable<E> ReadAll();

        void Add(E entity);
    }
}
