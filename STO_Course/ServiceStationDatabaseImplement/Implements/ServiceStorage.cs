using Microsoft.EntityFrameworkCore;
using ServiceStationContracts.BindingModels;
using ServiceStationContracts.SearchModels;
using ServiceStationContracts.StoragesContracts;
using ServiceStationContracts.ViewModels;
using ServiceStationDatabaseImplement;
using ServiceStationDatabaseImplement.Models;

namespace ServiceStationDatabaseImplement.Implements
{
    public class ServiceStorage : IServiceStorage
    {
        public List<ServiceViewModel> GetFullList()
        {
            using var context = new ServiceStationDatabase();
            return context.Services.Select(x => x.GetViewModel).ToList();
        }

        public List<ServiceViewModel> GetFilteredList(ServiceSearchModel model)
        {
            using var context = new ServiceStationDatabase();
            return context.Services.Select(x => x.GetViewModel).ToList();
        }

        public ServiceViewModel? GetElement(ServiceSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ServiceDescription) && !model.Id.HasValue)
            {
                return null;
            }
            using var context = new ServiceStationDatabase();
            return context.Services.FirstOrDefault(x =>
            (!string.IsNullOrEmpty(model.ServiceDescription) && x.ServiceDescription == model.ServiceDescription) ||
            (model.Id.HasValue && x.Id == model.Id))
                ?.GetViewModel;
        }

        public ServiceViewModel? Insert(ServiceBindingModel model)
        {
            using var context = new ServiceStationDatabase();
            var newService = Service.Create(model);
            if (newService == null)
            {
                return null;
            }
            context.Services.Add(newService);
            context.SaveChanges();
            return newService.GetViewModel;
        }

        public ServiceViewModel? Update(ServiceBindingModel model)
        {
            using var context = new ServiceStationDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var Service = context.Services.FirstOrDefault(rec => rec.Id == model.Id);
                if (Service == null)
                {
                    return null;
                }
                Service.Update(model);
                context.SaveChanges();
                transaction.Commit();
                return Service.GetViewModel;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public ServiceViewModel? Delete(ServiceBindingModel model)
        {
            using var context = new ServiceStationDatabase();
            var element = context.Services.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Services.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }
    }
}
