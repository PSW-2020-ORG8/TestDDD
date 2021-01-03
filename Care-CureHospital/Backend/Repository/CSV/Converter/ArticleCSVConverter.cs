// File:    ArticleCSVConverter.cs
// Author:  Hacer
// Created: ponedeljak, 25. maj 2020. 01:41:55
// Purpose: Definition of Class ArticleCSVConverter

using Model.AllActors;
using Model.BlogAndNotification;
using System;
using System.Collections.Generic;

namespace Repository.Csv.Converter
{
    public class ArticleCSVConverter : ICSVConverter<Article>
    {
        private readonly string delimiter;

        public ArticleCSVConverter(string delimiter)
        {
            this.delimiter = delimiter;
        }

        public string ConvertEntityToCSVFormat(Article entity)
        {
            String comentsCSV = "";
            foreach (Comment comment in entity.Comments) 
            {
                comentsCSV += string.Join(delimiter, comment.GetId());
                comentsCSV += delimiter;
            }
            return string.Join(delimiter, entity.GetId(), entity.Title, entity.Blog.GetId(), comentsCSV);
        }

        public Article ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(delimiter.ToCharArray());
            List<Comment> coments = new List<Comment>();
            FillList(coments, tokens);
            return new Article(int.Parse(tokens[0]), tokens[1], new Blog(int.Parse(tokens[2])), coments);
        }
      
        private void FillList(List<Comment> coments, string[] tokens)
        {
            int i = 3;
            while (i < tokens.Length - 1)
            {
                int id = int.Parse(tokens[i]);
                coments.Add(new Comment(id));          // Pozvati iz servisa ili repo metodu za get
                i++;
            }
        }
    }
}