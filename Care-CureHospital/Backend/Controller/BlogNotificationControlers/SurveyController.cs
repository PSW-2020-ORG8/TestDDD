/***********************************************************************
 * Module:  SurveyService.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Service.SurveyService
 ***********************************************************************/

using Backend.Service.ExaminationSurgeryServices;
using Model.Patient;
using System;
using System.Collections.Generic;

namespace Controller.BlogNotificationControlers
{
    public class SurveyController : IController<Survey, int>
    {
        public SurveyService surveyService;

        public SurveyController(SurveyService surveyService)
        {
            this.surveyService = surveyService;
        }

        public Survey GetEntity(int id)
        {
            return surveyService.GetEntity(id);
        }

        public IEnumerable<Survey> GetAllEntities()
        {
            return surveyService.GetAllEntities();
        }

        public Survey AddEntity(Survey entity)
        {
            return surveyService.AddEntity(entity);
        }

        public void UpdateEntity(Survey entity)
        {
            surveyService.UpdateEntity(entity);
        }

        public void DeleteEntity(Survey entity)
        {
            surveyService.DeleteEntity(entity);
        }

    }
}