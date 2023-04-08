using ServiceStationContracts.BindingModels;
using ServiceStationContracts.SearchModels;
using ServiceStationContracts.StoragesContracts;
using ServiceStationContracts.ViewModels;
using ServiceStationDatabaseImplement.Models;

namespace ServiceStationDatabaseImplement.Implements
{
    public class WorkStorage : IWorkStorage
    {
        public List<WorkViewModel> GetFullList()
        {
            using var context = new ServiceStationDatabase();
            return context.Works.Select(x => x.GetViewModel).ToList();
        }

        public List<WorkViewModel> GetFilteredList(WorkSearchModel model)
        {
            if(string.IsNullOrEmpty(model.Title))
            {
                return new();
            }
            using var context = new ServiceStationDatabase();
            return context.Works.Select(x => x.GetViewModel).ToList();
        }

        public WorkViewModel? GetElement(WorkSearchModel model)
        {
            if (!model.Id.HasValue && string.IsNullOrEmpty(model.Title))
            {
                return null;
            }
            using var context = new ServiceStationDatabase();
            return context.Works.FirstOrDefault(x => (model.Id.HasValue && x.Id == model.Id) ||
            (!string.IsNullOrEmpty(model.Title) && x.Title == model.Title))?.GetViewModel;
        }

        public WorkViewModel? Insert(WorkBindingModel model)
        {
            using var context = new ServiceStationDatabase();
            var newWork = Work.Create(context, model);
            if(newWork == null)
            {
                return null;
            }
            context.Works.Add(newWork);
            context.SaveChanges();
            return newWork.GetViewModel;
        }

        public WorkViewModel? Update(WorkBindingModel model)
        {
            using var context = new ServiceStationDatabase();
            var work = context.Works.FirstOrDefault(x=>x.Id == model.Id);
            if(work == null)
            {
                return null;
            }
            work.Update(model);
            work.UpdateSpares(context, model);
            context.SaveChanges();
            return work.GetViewModel;
        }

        public WorkViewModel? Delete(WorkBindingModel model)
        {
            using var context = new ServiceStationDatabase();
            var work = context.Works.FirstOrDefault(x=>x.Id==model.Id);
            if(work != null)
            {
                context.Works.Remove(work);
                context.SaveChanges();
                return work.GetViewModel;
            }
            return null;
        }
    }
}
