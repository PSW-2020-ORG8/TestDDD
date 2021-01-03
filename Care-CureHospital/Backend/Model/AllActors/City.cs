/***********************************************************************
 * Module:  City.cs
 * Author:  Stefan
 * Purpose: Definition of the Class AllActors.City
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Model.AllActors
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PostCode { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public City()
        {
        }

        public City(string name, string address, Country country)
        {
            Name = name;
            Address = address;
            CountryId = country.Id;
            Country = country;
        }

        public City(string name, int postCode, string address, Country country)
        {
            Name = name;
            PostCode = postCode;
            Address = address;
            CountryId = country.Id;
            Country = country;
        }

    }
}