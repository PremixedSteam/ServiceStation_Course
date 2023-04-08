
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
    public class SpareStorage : ISpareStorage
    {
        public List<SpareViewModel> GetFullList()
        {
            using var context = new ServiceStationDatabase();
            return context.Spares.Select(x => x.GetViewModel).ToList();
        }

        public List<SpareViewModel> GetFilteredList(SpareSearchModel model)
        {
            using var context = new ServiceStationDatabase();
            return context.Spares.Select(x => x.GetViewModel).ToList();
        }

        public SpareViewModel? GetElement(SpareSearchModel model)
        {
            if (!model.Id.HasValue)
            {
                return null;
            }
            using var context = new ServiceStationDatabase();
            return context.Spares.FirstOrDefault(x => (model.Id.HasValue && x.Id == model.Id))?.GetViewModel;
        }

        public SpareViewModel? Insert(SpareBindingModel model)
        {
            using var context = new ServiceStationDatabase();
            var newSpares = Spare.Create( model);
            if(newSpares == null)
            {
                return null;
            }
            context.Spares.Add(newSpares);
            context.SaveChanges();
            return newSpares.GetViewModel;
        }

        public SpareViewModel? Update(SpareBindingModel model)
        {
            using var context = new ServiceStationDatabase();
            var spares = context.Spares.FirstOrDefault(x=>x.Id == model.Id);
            if(spares == null)
            {
                return null;
            }
            spares.Update(model);
            context.SaveChanges();
            return spares.GetViewModel;
        }

        public SpareViewModel? Delete(SpareBindingModel model)
        {
            using var context = new ServiceStationDatabase();
            var spare = context.Spares.FirstOrDefault(x=>x.Id==model.Id);
            if(spare != null)
            {
                context.Spares.Remove(spare);
                context.SaveChanges();
                return spare.GetViewModel;
            }
            return null;
        }
    }
}
