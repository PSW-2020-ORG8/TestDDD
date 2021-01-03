// File:    RoomCSVConverter.cs
// Author:  Hacer
// Created: ponedeljak, 25. maj 2020. 01:41:55
// Purpose: Definition of Class RoomCSVConverter

using Model.Manager;
using Repository.RoomsRepository;
using Model.Term;
using System;
using System.Collections.Generic;

namespace Repository.Csv.Converter
{
    public class RoomCSVConverter : ICSVConverter<Room>
    {
        private readonly string delimiter;
        private const string DATETIME_FORMAT = "dd.MM.yyyy.";

        public RoomCSVConverter(string delimiter)
        {
            this.delimiter = delimiter;
        }

        public string ConvertEntityToCSVFormat(Room entity)
        {
            String equipmentCSV = "";
            foreach (InventaryRoom equipment in entity.Equipment)
            {
                equipmentCSV += string.Join(delimiter, equipment.GetId());
                equipmentCSV += delimiter;
            }
            return string.Join(delimiter, entity.GetId(), entity.RoomId, entity.TypeOfRoom.NameOfType, entity.FromDateTime.ToString(DATETIME_FORMAT), entity.ToDateTime.ToString(DATETIME_FORMAT), equipmentCSV);
        }

        public Room ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(delimiter.ToCharArray());
            List<InventaryRoom> equipments = new List<InventaryRoom>();
            FillList(equipments, tokens);
            return new Room(int.Parse(tokens[0]), tokens[1], new TypeOfRoom(tokens[2]), DateTime.Parse(tokens[3]), DateTime.Parse(tokens[4]), equipments);
        }

        private void FillList(List<InventaryRoom> equipment, string[] tokens)
        {
            int i = 5;
            while (i < tokens.Length - 1)
            {
                int id = int.Parse(tokens[i]);
                equipment.Add(InventaryRoomRepository.Instance().GetEntity(id)); 
                i++;
            }
        }
    }
}