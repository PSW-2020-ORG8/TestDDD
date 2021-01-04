using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroservice.Domain
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Country()
        {
        }

        public Country(string name)
        {
            Name = name;
        }
    }
}
