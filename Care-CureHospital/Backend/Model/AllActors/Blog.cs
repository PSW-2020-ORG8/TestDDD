/***********************************************************************
 * Module:  Blog.cs
 * Author:  Stefan
 * Purpose: Definition of the Class AllActors.Blog
 ***********************************************************************/

using HealthClinic.Repository;
using Model.BlogAndNotification;
using System;
using System.Collections.Generic;

namespace Model.AllActors
{
    public class Blog : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Article> Articles { get; set; }

        public Blog(int id)
        {
            Id = id;
        }

        public Blog()
        {
        }

        public Blog(int id, string name, List<Article> articles)
        {
            Name = name;
            Articles = articles;
            Id = id;
        }

        public Blog(string name, List<Article> articles)
        {
            Name = name;
            Articles = articles;
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}