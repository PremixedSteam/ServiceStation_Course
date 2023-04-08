using ServiceStationContracts.BindingModels;
using ServiceStationContracts.SearchModels;
using ServiceStationContracts.ViewModels;

namespace ServiceStationContracts.BusinessLogicsContracts
{
    public interface IMaintenanceLogic
    {
        List<MaintenanceViewModel>? ReadList(MaintenanceSearchModel? model);
        MaintenanceViewModel? ReadElement(MaintenanceSearchModel? model);
        bool Create(MaintenanceBindingModel model);
        bool Update(MaintenanceBindingModel model);
        bool Delete(MaintenanceBindingModel model);
    }
}
