/***********************************************************************
 * Module:  FeedbackOfValidation.cs
 * Author:  Stefan
 * Purpose: Definition of the Class DoctorMenager.FeedbackOfValidation
 ***********************************************************************/

using System;

namespace Model.DoctorMenager
{
    public class FeedbackOfValidation
    {
        public string Comment { get; set; }
        public FeedbackOfValidation()
        {
        }

        public FeedbackOfValidation(string comment)
        {
            Comment = comment;
        }

       
    }
}