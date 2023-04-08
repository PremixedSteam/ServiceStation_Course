using ServiceStationContracts.BindingModels;
using ServiceStationContracts.SearchModels;
using ServiceStationContracts.ViewModels;

namespace ServiceStationContracts.BusinessLogicsContracts
{
    public interface IWorkDurationLogic
    {
        List<WorkDurationViewModel>? ReadList(WorkDurationSearchModel? model);
        WorkDurationViewModel? ReadElement(WorkDurationSearchModel? model);
        bool Create(WorkDurationBindingModel model);
        bool Update(WorkDurationBindingModel model);
        bool Delete(WorkDurationBindingModel model);
    }
}
