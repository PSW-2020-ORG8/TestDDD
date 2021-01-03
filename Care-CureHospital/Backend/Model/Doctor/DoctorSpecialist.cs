/***********************************************************************
 * Module:  AllRounderDoctor.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Doctor.AllRounderDoctor
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Model.Doctor
{
   public class DoctorSpecialist : AllActors.Doctor
   {
      public virtual List<Specialitation> specialitation { get; set; }

        public DoctorSpecialist()
        {
        }
      
   }
}