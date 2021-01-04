using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroservice.Repository
{
    public interface IIdentifiable<T>
    {
        T GetId();
        void SetId(T id);
    }
}
