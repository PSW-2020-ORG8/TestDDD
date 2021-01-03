// File:    SurveyCSVConverter.cs
// Author:  Hacer
// Created: ponedeljak, 25. maj 2020. 01:41:55
// Purpose: Definition of Class SurveyCSVConverter

using Model.AllActors;
using Model.Patient;
using Repository.UsersRepository;
using System;
using System.Collections.Generic;
using System.Globalization;


namespace Repository.Csv.Converter
{
    public class SurveyCSVConverter : ICSVConverter<Survey>
    {
        private readonly string delimiter;

        public SurveyCSVConverter(string delimiter)
        {
            this.delimiter = delimiter;
        }
       
        public string ConvertEntityToCSVFormat(Survey entity)
        {
            throw new NotImplementedException();
        }

        public Survey ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            throw new NotImplementedException();
        }

        private void FillList(List<Question> questions, string[] tokens)
        {
            int i = 5;
            while (i < tokens.Length - 1)
            {
                questions.Add(new Question(tokens[i]));
                i++;
            }
        }
    }
}