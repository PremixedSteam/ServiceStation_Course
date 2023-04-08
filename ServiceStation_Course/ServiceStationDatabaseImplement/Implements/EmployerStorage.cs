using ServiceStationContracts.BindingModels;
using ServiceStationContracts.SearchModels;
using ServiceStationContracts.StoragesContracts;
using ServiceStationContracts.ViewModels;
using ServiceStationDatabaseImplement.Models;

namespace ServiceStationDatabaseImplement.Implements
{
    public class EmployerStorage : IEmployerStorage
    {
        public List<EmployerViewModel> GetFullList()
        {
            using var context = new ServiceStationDatabase();
            return context.Employers.Select(x => x.GetViewModel).ToList();
        }

        public List<EmployerViewModel> GetFilteredList(EmployerSearchModel model)
        {
            if (string.IsNullOrEmpty(model.Login) && string.IsNullOrEmpty(model.Email))
            {
                return new();
            }
            using var context = new ServiceStationDatabase();
            return context.Employers.Where(x => (!string.IsNullOrEmpty(model.Login) && x.Login.Contains(model.Login)) ||
            (!string.IsNullOrEmpty(model.Email) && !x.Email.Contains(model.Email))).Select(x => x.GetViewModel).ToList();
        }

        public EmployerViewModel? GetElement(EmployerSearchModel model)
        {
            if (!model.Id.HasValue && string.IsNullOrEmpty(model.Login) && (string.IsNullOrEmpty(model.Email) && string.IsNullOrEmpty(model.Password)))
            {
                return null;
            }
            using var context = new ServiceStationDatabase();
            return context.Employers.FirstOrDefault(x => (model.Id.HasValue && x.Id == model.Id) ||
            (!string.IsNullOrEmpty(model.Login) && x.Login == model.Login) ||
            (!string.IsNullOrEmpty(model.Email) && !string.IsNullOrEmpty(model.Password) && x.Email == model.Email && x.Password == model.Password))?.GetViewModel;
        }

        public EmployerViewModel? Insert(EmployerBindingModel model)
        {
            var newEmployer = Employer.Create(model);
            if (newEmployer == null)
            {
                return null;
            }
            using var context = new ServiceStationDatabase();
            context.Employers.Add(newEmployer);
            context.SaveChanges();
            return newEmployer.GetViewModel;
        }

        public EmployerViewModel? Update(EmployerBindingModel model)
        {
            using var context = new ServiceStationDatabase();
            var storekeeper = context.Employers.FirstOrDefault(x => x.Id == model.Id);
            if (storekeeper == null)
            {
                return null;
            }
            storekeeper.Update(model);
            context.SaveChanges();
            return storekeeper.GetViewModel;
        }

        public EmployerViewModel? Delete(EmployerBindingModel model)
        {
            using var context = new ServiceStationDatabase();
            var storekeeper = context.Employers.FirstOrDefault(x => x.Id == model.Id);
            if (storekeeper != null)
            {
                context.Employers.Remove(storekeeper);
                context.SaveChanges();
                return storekeeper.GetViewModel;
            }
            return null;
        }
    }
}
