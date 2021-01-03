// File:    IArticleRepository.cs
// Author:  Stefan
// Created: cetvrtak, 28. maj 2020. 00:48:42
// Purpose: Definition of Interface IArticleRepository

using Model.BlogAndNotification;
using System;

namespace Repository.BlogNotificationRepository
{
    public interface IArticleRepository : IRepository<Article, int>
    {
    }
}