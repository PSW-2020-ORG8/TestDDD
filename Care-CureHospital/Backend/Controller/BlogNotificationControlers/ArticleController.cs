/***********************************************************************
 * Module:  ArticleService.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Service.ArticleService
 ***********************************************************************/

using Model.BlogAndNotification;
using System;
using System.Collections.Generic;
using Service.BlogNotificationServices;

namespace Controller.BlogNotificationControlers
{
    public class ArticleController : IController<Article, int>
    {
        public ArticleService articleService;

        public ArticleController(ArticleService articleService)
        {
            this.articleService = articleService;
        }

        public Article AddEntity(Article entity)
        {
            return articleService.AddEntity(entity);
        }

        public void DeleteEntity(Article entity)
        {
            articleService.DeleteEntity(entity);
        }

        public IEnumerable<Article> GetAllEntities()
        {
            return articleService.GetAllEntities();
        }

        public Article GetEntity(int id)
        {
            return articleService.GetEntity(id);
        }

        public void UpdateEntity(Article entity)
        {
            articleService.UpdateEntity(entity);
        }

    }
}