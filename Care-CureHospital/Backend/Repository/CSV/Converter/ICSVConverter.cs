// File:    ICSVConverter.cs
// Author:  Hacer
// Created: ponedeljak, 25. maj 2020. 01:41:55
// Purpose: Definition of Interface ICSVConverter

using System;

namespace Repository.Csv.Converter
{
   public interface ICSVConverter<E> where E : class
   {
      string ConvertEntityToCSVFormat(E entity);
  
      
      E ConvertCSVFormatToEntity(string entityCSVFormat);
   
   }
}