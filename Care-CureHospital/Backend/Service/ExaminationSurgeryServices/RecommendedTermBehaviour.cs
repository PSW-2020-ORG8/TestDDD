// File:    RecommendedTermBehaviour.cs
// Author:  Hacer
// Created: subota, 30. maj 2020. 22:08:24
// Purpose: Definition of Class RecommendedTermBehaviour

using System;
using Model.Term;
using Model.AllActors;
using Repository.ExaminationSurgeryRepository;

namespace Service.ExaminationSurgeryServices
{
    public class RecommendedTermBehaviour : IRecommendationBehaviour
    {
        public IMedicalExaminationRepository iMedicalExaminationRepository;

        public MedicalExamination RecommendMedicalExamination(Doctor doctor, Term dateRange)
        {
            throw new NotImplementedException();
        }

    }
}