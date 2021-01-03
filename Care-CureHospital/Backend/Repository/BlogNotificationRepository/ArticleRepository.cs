/***********************************************************************
 * Module:  UserRepository.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Repository.UserRepository
 ***********************************************************************/

using Backend.Repository.MySQL;
using Backend.Repository.MySQL.Stream;
using Model.BlogAndNotification;
using Repository.Csv;
using Repository.Csv.Converter;
using Repository.Csv.Stream;
using Repository.IDSequencer;
using System;
using System.Collections.Generic;

namespace Repository.BlogNotificationRepository
{
    public class ArticleRepository : MySQLRepository<Article, int>, IArticleRepository
    {
        private const string ARTICLE_FILE = "../../Resources/Data/articles.csv";
        private static ArticleRepository instance;

        public static ArticleRepository Instance()
        {
            if (instance == null)
            {
                instance = new ArticleRepository(new MySQLStream<Article>(), new IntSequencer());
            }
            return instance;

        }

        public ArticleRepository(IMySQLStream<Article> stream, ISequencer<int> sequencer)
            : base(stream, sequencer)
        {
        }
    }
}