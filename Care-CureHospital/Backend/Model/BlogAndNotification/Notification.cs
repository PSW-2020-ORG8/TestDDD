/***********************************************************************
 * Module:  Notification.cs
 * Author:  Hacer
 * Purpose: Definition of the Class Patient.Notification
 ***********************************************************************/

using HealthClinic.Repository;
using Model.AllActors;
using System;
using System.Collections.Generic;

namespace Model.BlogAndNotification
{
    public class Notification : Content, IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public virtual User SendNotificationByUser { get; set; }
        public virtual List<User> ReceiveNotifications { get; set; }

        public Notification(int id)
        {
            Id = id;
        }

        public Notification()
        {
        }

        public Notification(int id, string title, User sendNotificationByUser, List<User> receiveNotifications)
        {
            Title = title;
            Id = id;
            SendNotificationByUser = sendNotificationByUser;
            ReceiveNotifications = receiveNotifications;
        }

        public Notification(string title, User sendNotificationByUser, List<User> receiveNotifications)
        {
            Title = title;
            SendNotificationByUser = sendNotificationByUser;
            ReceiveNotifications = receiveNotifications;
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