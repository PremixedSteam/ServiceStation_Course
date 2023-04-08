using ServiceStationContracts.BindingModels;
using ServiceStationContracts.SearchModels;
using ServiceStationContracts.ViewModels;

namespace ServiceStationContracts.StoragesContracts
{
    public interface IWorkDurationStorage
    {
        List<WorkDurationViewModel> GetFullList();
        List<WorkDurationViewModel> GetFilteredList(WorkDurationSearchModel model);
        WorkDurationViewModel? GetElement(WorkDurationSearchModel model);
        WorkDurationViewModel? Insert(WorkDurationBindingModel model);
        WorkDurationViewModel? Update(WorkDurationBindingModel model);
        WorkDurationViewModel? Delete(WorkDurationBindingModel model);
    }
}
