
using ServiceStationContracts.BindingModels;
using ServiceStationContracts.SearchModels;
using ServiceStationContracts.StoragesContracts;
using ServiceStationContracts.ViewModels;
using ServiceStationDatabaseImplement;
using ServiceStationDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStationDatabaseImplement.Implements
{
    public class StorekeeperStorage : IStorekeeperStorage
    {
        public List<StorekeeperViewModel> GetFullList()
        {
            using var context = new ServiceStationDatabase();
            return context.Storekeepers.Select(x => x.GetViewModel).ToList();
        }

        public List<StorekeeperViewModel> GetFilteredList(StorekeeperSearchModel model)
        {
            if(string.IsNullOrEmpty(model.Login) && string.IsNullOrEmpty(model.Email))
            {
                return new();
            }
            using var context = new ServiceStationDatabase();
            return context.Storekeepers.Where(x => (!string.IsNullOrEmpty(model.Login) && x.Login.Contains(model.Login)) ||
            (!string.IsNullOrEmpty(model.Email) && !x.Email.Contains(model.Email))).Select(x => x.GetViewModel).ToList();
        }

        public StorekeeperViewModel? GetElement(StorekeeperSearchModel model)
        {
            if (!model.Id.HasValue && string.IsNullOrEmpty(model.Login) && (string.IsNullOrEmpty(model.Email) && string.IsNullOrEmpty(model.Password)))
            {
                return null;
            }
            using var context = new ServiceStationDatabase();
            return context.Storekeepers.FirstOrDefault(x => (model.Id.HasValue && x.Id == model.Id) ||
            (!string.IsNullOrEmpty(model.Login) && x.Login == model.Login) ||
            (!string.IsNullOrEmpty(model.Email) && !string.IsNullOrEmpty(model.Password) && x.Email == model.Email && x.Password == model.Password))?.GetViewModel;
        }

        public StorekeeperViewModel? Insert(StorekeeperBindingModel model)
        {
            var newStorekeeper = Storekeeper.Create(model);
            if(newStorekeeper == null)
            {
                return null;
            }
            using var context = new ServiceStationDatabase();
            context.Storekeepers.Add(newStorekeeper);
            context.SaveChanges();
            return newStorekeeper.GetViewModel;
        }

        public StorekeeperViewModel? Update(StorekeeperBindingModel model)
        {
            using var context = new ServiceStationDatabase();
            var storekeeper = context.Storekeepers.FirstOrDefault(x=>x.Id == model.Id);
            if(storekeeper == null)
            {
                return null;
            }
            storekeeper.Update(model);
            context.SaveChanges();
            return storekeeper.GetViewModel;
        }

        public StorekeeperViewModel? Delete(StorekeeperBindingModel model)
        {
            using var context = new ServiceStationDatabase();
            var storekeeper = context.Storekeepers.FirstOrDefault(x=>x.Id==model.Id);
            if(storekeeper != null)
            {
                context.Storekeepers.Remove(storekeeper);
                context.SaveChanges();
                return storekeeper.GetViewModel;
            }
            return null;
        }
    }
}
