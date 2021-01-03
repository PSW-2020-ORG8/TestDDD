// File:    RecommendationMedicalExaminationService.cs
// Author:  Hacer
// Created: subota, 30. maj 2020. 22:08:23
// Purpose: Definition of Class RecommendationMedicalExaminationService

using System;
using Model.Term;
using Model.AllActors;

namespace Service.ExaminationSurgeryServices
{
    public class RecommendationMedicalExaminationService
    {
        public IRecommendationBehaviour iRecommendationBehaviour;

        public MedicalExamination RecommendMedicalExamination(Doctor doctor, Term dateRange)
        {
            throw new NotImplementedException();
        }

    }
}