using HospitalMap.Code.Model;
using HospitalMap.Code.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HospitalMap.Code.Service
{
    class StorageService
    {
        public StorageRepository StorageRepository;

        public StorageService(StorageRepository storageRepository)
        {
            this.StorageRepository = storageRepository;
        }

        public StorageService()
        {
        }

        public ObservableCollection<StorageModel> GetAllStorage()
        {
            ObservableCollection<StorageModel> logins = new ObservableCollection<StorageModel>();


            logins = StorageRepository.GetInstance().GetAllStorage();


            return logins;
        }
    }
}
