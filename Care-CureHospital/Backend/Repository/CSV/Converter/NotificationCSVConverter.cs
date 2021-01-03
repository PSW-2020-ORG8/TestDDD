// File:    NotificationCSVConverter.cs
// Author:  Hacer
// Created: ponedeljak, 25. maj 2020. 01:41:55
// Purpose: Definition of Class NotificationCSVConverter

using Model.AllActors;
using Model.BlogAndNotification;
using Repository.UsersRepository;
using System;
using System.Collections.Generic;

namespace Repository.Csv.Converter
{
    public class NotificationCSVConverter : ICSVConverter<Notification>
    {
        private readonly string delimiter;

        public NotificationCSVConverter(string delimiter)
        {
            this.delimiter = delimiter;
        }

        public string ConvertEntityToCSVFormat(Notification entity)
        {
            String receiveNotificationsCSV = "";
            foreach (User user in entity.ReceiveNotifications)
            {
                receiveNotificationsCSV += string.Join(delimiter, user.GetId());
                receiveNotificationsCSV += delimiter;
            }

            return string.Join(delimiter, entity.GetId(), entity.Title, entity.SendNotificationByUser.GetId(), receiveNotificationsCSV);
        }

        public Notification ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(delimiter.ToCharArray());
            List<User> receiveNotifications = new List<User>();
            FillList(receiveNotifications, tokens);
            return new Notification(int.Parse(tokens[0]), tokens[1], UserRepository.Instance().GetEntity(int.Parse(tokens[2])), receiveNotifications);
        }

        private void FillList(List<User> receiveNotifications, string[] tokens)
        {
            int i = 3;
            while (i < tokens.Length - 1)
            {
                int id = int.Parse(tokens[i]);
                receiveNotifications.Add(UserRepository.Instance().GetEntity(int.Parse(tokens[i])));     
                i++;
            }
        }
    }
}