using ServiceStationContracts.BindingModels;
using ServiceStationContracts.SearchModels;
using ServiceStationContracts.ViewModels;

namespace ServiceStationContracts.BusinessLogicsContracts
{
    public interface IEmployerLogic
    {
        List<EmployerViewModel>? ReadList(EmployerSearchModel? model);
        EmployerViewModel? ReadElement(EmployerSearchModel? model);
        bool Create(EmployerBindingModel model);
        bool Update(EmployerBindingModel model);
        bool Delete(EmployerBindingModel model);
    }
}
