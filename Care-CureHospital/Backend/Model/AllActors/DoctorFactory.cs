// File:    DoctorFactory.cs
// Author:  Stefan
// Created: nedelja, 31. maj 2020. 19:56:44
// Purpose: Definition of Class DoctorFactory

using System;

namespace Model.AllActors
{
   public class DoctorFactory : UserFactory
   {
      public User CreateUser()
      {
         throw new NotImplementedException();
      }
   
   }
}