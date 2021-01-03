using HospitalMap.Code.Model;
using HospitalMap.Code.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HospitalMap.Code.Controller
{
    class StorageController
    {
        public StorageService StorageService;

        public StorageController()
        {

            this.StorageService = new StorageService();

        }

        public ObservableCollection<StorageModel> GetAllStorage()
        {
            return StorageService.GetAllStorage();
        }
    }
}
