/***********************************************************************
 * Module:  Termin.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Term.Termin
 ***********************************************************************/

using System;

namespace Model.Term
{
    public abstract class Term
    {
        public DateTime FromDateTime { get; set; }
        public DateTime ToDateTime { get; set; }

        public Term(DateTime fromDateTime, DateTime toDateTime)
        {
            FromDateTime = fromDateTime;
            ToDateTime = toDateTime;
        }

        public Term()
        {
            
        }
    }
}