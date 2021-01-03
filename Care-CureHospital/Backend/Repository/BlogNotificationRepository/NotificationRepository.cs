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

namespace Repository.BlogNotificationRepository
{
    public class NotificationRepository : MySQLRepository<Notification, int>, INotificationRepository
    {
        private const string NOTIFICATION_FILE = "../../Resources/Data/notifications.csv";
        private static NotificationRepository instance;

        public static NotificationRepository Instance()
        {
            if (instance == null)
            {
                instance = new NotificationRepository(new MySQLStream<Notification>(), new IntSequencer());
            }
            return instance;
        }

        public NotificationRepository(IMySQLStream<Notification> stream, ISequencer<int> sequencer)
             : base(stream, sequencer)
        {
        }
    }
}