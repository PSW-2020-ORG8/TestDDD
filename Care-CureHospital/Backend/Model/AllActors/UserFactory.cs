// File:    UserFactory.cs
// Author:  Stefan
// Created: nedelja, 31. maj 2020. 19:56:14
// Purpose: Definition of Interface UserFactory

using System;

namespace Model.AllActors
{
   public interface UserFactory
   {
      User CreateUser();
   
   }
}