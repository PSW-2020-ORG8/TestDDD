/***********************************************************************
 * Module:  NotificationService.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Service.NotificationService
 ***********************************************************************/

using Model.AllActors;
using Model.BlogAndNotification;
using Repository.BlogNotificationRepository;
using System;
using System.Collections.Generic;

namespace Service.BlogNotificationServices
{
    public class NotificationService : IService<Notification, int>
    {
        public INotificationRepository notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            this.notificationRepository = notificationRepository;
        }

        public List<Notification> GetAllNotificationsForUser(int userID)
        {
            List<Notification> notifications = new List<Notification>();
            foreach (Notification notification in notificationRepository.GetAllEntities())
                foreach (User user in notification.ReceiveNotifications)
                    if (user.GetId() == userID)
                        notifications.Add(notification);
            return notifications;
        }

        public Notification GetEntity(int id)
        {
            return notificationRepository.GetEntity(id);
        }

        public IEnumerable<Notification> GetAllEntities()
        {
            return notificationRepository.GetAllEntities();
        }

        public Notification AddEntity(Notification entity)
        {
            return notificationRepository.AddEntity(entity);
        }

        public void UpdateEntity(Notification entity)
        {
            notificationRepository.UpdateEntity(entity);
        }

        public void DeleteEntity(Notification entity)
        {
            notificationRepository.DeleteEntity(entity);
        }

    }
}