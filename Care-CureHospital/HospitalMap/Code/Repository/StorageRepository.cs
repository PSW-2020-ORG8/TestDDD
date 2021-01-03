using HospitalMap.Code.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace HospitalMap.Code.Repository
{
    class StorageRepository
    {
        private const String _path = @"./../../../Code/Resources/storage.txt";

        private static StorageRepository _instance = null;

        private ObservableCollection<StorageModel> _searched = new ObservableCollection<StorageModel>();

        public static StorageRepository GetInstance()
        {
            if (_instance == null)
            {
                _instance = new StorageRepository();
            }
            return _instance;
        }
        public ObservableCollection<StorageModel> Storage
        {
            get;
            set;

        }
        public ObservableCollection<StorageModel> GetAllStorage()
        {
            String text = "";

            if (File.Exists(_path))
                text = File.ReadAllText(_path);



            return JsonConvert.DeserializeObject<ObservableCollection<StorageModel>>(text);

        }
        public ObservableCollection<StorageModel> SearchedItemsByName(string search)
        {
            _searched.Clear();
            foreach (StorageModel equipment in GetAllStorage())
            {
                if (equipment.Name.ToLower().Contains(search.ToLower()))
                {
                    _searched.Add(equipment);
                }
            }

            return _searched;
        }
        public ObservableCollection<StorageModel> SearchedItemsByNameForStorage(string search)
        {
            _searched.Clear();
            foreach (StorageModel equipment in GetAllStorage())
            {
                if (equipment.Name.ToLower().Contains(search.ToLower()) && equipment.Location.Equals(""))
                {
                    _searched.Add(equipment);
                }
            }

            return _searched;
        }
        public ObservableCollection<StorageModel> SearchedItemsByRoom(string search)
        {
            _searched.Clear();
            foreach (StorageModel equipment in GetAllStorage())
            {
                if (equipment.Location.Equals(search))
                {
                    _searched.Add(equipment);
                }
            }

            return _searched;
        }
        public StorageModel GetById(String id)
        {
            foreach (StorageModel stor in Storage)
            {
                if (stor.Id.Equals(id))
                {
                    return stor;
                }
            }
            return null;

        }

        public ObservableCollection<StorageModel> GetAllById(String idOfStorage)
        {
            ObservableCollection<StorageModel> equipmentsInThisIdStorage = new ObservableCollection<StorageModel>();
            foreach (StorageModel stor in GetAllStorage())
            {
                if (stor.IdS.Equals(idOfStorage) && stor.Location.Equals(idOfStorage))
                {
                    equipmentsInThisIdStorage.Add(stor);
                }
            }
            return equipmentsInThisIdStorage;

        }
    }
}
