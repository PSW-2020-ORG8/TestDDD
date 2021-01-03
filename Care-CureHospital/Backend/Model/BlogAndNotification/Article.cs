/***********************************************************************
 * Module:  Article.cs
 * Author:  Hacer
 * Purpose: Definition of the Class Blog.Article
 ***********************************************************************/

using HealthClinic.Repository;
using Model.AllActors;
using System;
using System.Collections.Generic;

namespace Model.BlogAndNotification
{
    public class Article : Content, IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
        public virtual List<Comment> Comments { get; set; }

        public Article(int id)
        {
            Id = id;
        }

        public Article()
        {
        }

        public Article(int id, string title, Blog blog, List<Comment> comments)
        {
            Title = title;
            Id = id;
            Blog = blog;
            Comments = comments;
        }

        public Article(string title, Blog blog, List<Comment> comments)
        {
            Title = title;
            Blog = blog;
            Comments = comments;
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