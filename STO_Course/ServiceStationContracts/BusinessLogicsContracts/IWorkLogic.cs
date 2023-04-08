using ServiceStationContracts.BindingModels;
using ServiceStationContracts.SearchModels;
using ServiceStationContracts.ViewModels;

namespace ServiceStationContracts.BusinessLogicsContracts
{
    public interface IWorkLogic
    {
        List<WorkViewModel>? ReadList(WorkSearchModel? model);
        WorkViewModel? ReadElement(WorkSearchModel? model);
        bool Create(WorkBindingModel model);
        bool Update(WorkBindingModel model);
        bool Delete(WorkBindingModel model);
    }
}
