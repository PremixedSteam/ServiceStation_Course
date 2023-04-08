using ServiceStationContracts.BindingModels;
using ServiceStationContracts.SearchModels;
using ServiceStationContracts.ViewModels;

namespace ServiceStationContracts.BusinessLogicsContracts
{
    public interface IServiceLogic
    {
        List<ServiceViewModel>? ReadList(ServiceSearchModel? model);
        ServiceViewModel? ReadElement(ServiceSearchModel? model);
        bool Create(ServiceBindingModel model);
        bool Update(ServiceBindingModel model);
        bool Delete(ServiceBindingModel model);
    }
}
