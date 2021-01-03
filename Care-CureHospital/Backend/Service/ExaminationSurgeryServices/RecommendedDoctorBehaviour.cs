// File:    RecommendedDoctorBehaviour.cs
// Author:  Hacer
// Created: subota, 30. maj 2020. 22:08:25
// Purpose: Definition of Class RecommendedDoctorBehaviour

using System;
using Model.Term;
using Model.AllActors;
using Repository.ExaminationSurgeryRepository;

namespace Service.ExaminationSurgeryServices
{
    public class RecommendedDoctorBehaviour : IRecommendationBehaviour
    {
        public IMedicalExaminationRepository iMedicalExaminationRepository;

        public MedicalExamination RecommendMedicalExamination(Doctor doctor, Term dateRange)
        {
            throw new NotImplementedException();
        }
      
    }
}