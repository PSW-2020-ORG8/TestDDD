/***********************************************************************
 * Module:  NotificationService.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Service.NotificationService
 ***********************************************************************/

using Model.BlogAndNotification;
using Service.BlogNotificationServices;
using Model.AllActors;
using System;
using System.Collections.Generic;

namespace Controller.BlogNotificationControlers
{
    public class NotificationController : IController<Notification, int>
    {
        public NotificationService notificationService;

        public NotificationController(NotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        public List<Notification> GetAllNotificationsForUser(int userID)
        {
            return notificationService.GetAllNotificationsForUser(userID);
        }

        public Notification GetEntity(int id)
        {
            return notificationService.GetEntity(id);
        }

        public IEnumerable<Notification> GetAllEntities()
        {
            return notificationService.GetAllEntities();
        }

        public Notification AddEntity(Notification entity)
        {
            return notificationService.AddEntity(entity);
        }

        public void UpdateEntity(Notification entity)
        {
            notificationService.UpdateEntity(entity);
        }

        public void DeleteEntity(Notification entity)
        {
            notificationService.DeleteEntity(entity);
        }

    }
}