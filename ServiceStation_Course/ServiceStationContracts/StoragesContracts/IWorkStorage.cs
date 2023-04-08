using ServiceStationContracts.BindingModels;
using ServiceStationContracts.SearchModels;
using ServiceStationContracts.ViewModels;

namespace ServiceStationContracts.StoragesContracts
{
    public interface IWorkStorage
    {
        List<WorkViewModel> GetFullList();
        List<WorkViewModel> GetFilteredList(WorkSearchModel model);
        WorkViewModel? GetElement(WorkSearchModel model);
        WorkViewModel? Insert(WorkBindingModel model);
        WorkViewModel? Update(WorkBindingModel model);
        WorkViewModel? Delete(WorkBindingModel model);
    }
}
