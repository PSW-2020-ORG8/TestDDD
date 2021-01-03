/***********************************************************************
 * Module:  Content.cs
 * Author:  Hacer
 * Purpose: Definition of the Class Blog.Content
 ***********************************************************************/

using System;

namespace Model.BlogAndNotification
{
    public class Content
    {
        public string Text { get; set; }
        public DateTime PublishingDate { get; set; }

        public Content()
        {
        }

        public Content(string text, DateTime publishingDate)
        {
            Text = text;
            PublishingDate = publishingDate;
        }
    }
}