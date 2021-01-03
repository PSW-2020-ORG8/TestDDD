// File:    IRecommendationBehaviour.cs
// Author:  Hacer
// Created: subota, 30. maj 2020. 22:08:28
// Purpose: Definition of Interface IRecommendationBehaviour

using System;
using Model.AllActors;
using Model.Term;

namespace Service.ExaminationSurgeryServices
{
   public interface IRecommendationBehaviour
   {
      MedicalExamination RecommendMedicalExamination(Doctor doctor, Term dateRange);
   
   }
}