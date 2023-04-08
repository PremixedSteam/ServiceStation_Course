using Microsoft.EntityFrameworkCore;
using ServiceStationContracts.BindingModels;
using ServiceStationContracts.SearchModels;
using ServiceStationContracts.StoragesContracts;
using ServiceStationContracts.ViewModels;
using ServiceStationDatabaseImplement.Models;

namespace ServiceStationDatabaseImplement.Implements
{
    public class CarStorage : ICarStorage
    {
        public List<CarViewModel> GetFullList()
        {
            using var context = new ServiceStationDatabase();
            return context.Cars.Include(x => x.Spares).ThenInclude(x => x.Spare).ToList()
                    .Select(x => x.GetViewModel).ToList();
        }

        public List<CarViewModel> GetFilteredList(CarSearchModel model)
        {
            if (string.IsNullOrEmpty(model.Brand))
            {
                return new();
            }
            using var context = new ServiceStationDatabase();
            return context.Cars.Include(x => x.Spares).ThenInclude(x => x.Spare)
                    .Where(x => x.Brand.Contains(model.Brand)).ToList().Select(x => x.GetViewModel).ToList();
        }

        public CarViewModel? GetElement(CarSearchModel model)
        {
            if (string.IsNullOrEmpty(model.Brand) && !model.Id.HasValue)
            {
                return null;
            }
            using var context = new ServiceStationDatabase();
            return context.Cars.Include(x => x.Spares).ThenInclude(x => x.Spare)
                .FirstOrDefault(x =>
                (!string.IsNullOrEmpty(model.Brand) && x.Brand == model.Brand) ||
                (model.Id.HasValue && x.Id == model.Id))
                    ?.GetViewModel;
        }

        public CarViewModel? Insert(CarBindingModel model)
        {
            using var context = new ServiceStationDatabase();
            var newCar = Car.Create(context, model);
            if (newCar == null)
            {
                return null;
            }
            context.Cars.Add(newCar);
            context.SaveChanges();
            return newCar.GetViewModel;
        }

        public CarViewModel? Update(CarBindingModel model)
        {
            using var context = new ServiceStationDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var Car = context.Cars.FirstOrDefault(rec => rec.Id == model.Id);
                if (Car == null)
                {
                    return null;
                }
                Car.Update(model);
                context.SaveChanges();
                Car.UpdateComponents(context, model);
                transaction.Commit();
                return Car.GetViewModel;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public CarViewModel? Delete(CarBindingModel model)
        {
            using var context = new ServiceStationDatabase();
            var element = context.Cars.Include(x => x.Spares).FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Cars.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }


    }
}
