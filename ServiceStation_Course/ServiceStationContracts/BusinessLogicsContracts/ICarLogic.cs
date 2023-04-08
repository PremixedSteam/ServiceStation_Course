using ServiceStationContracts.BindingModels;
using ServiceStationContracts.SearchModels;
using ServiceStationContracts.ViewModels;

namespace ServiceStationContracts.BusinessLogicsContracts
{
    public interface ICarLogic
    {
        List<CarViewModel>? ReadList(CarSearchModel? model);
        CarViewModel? ReadElement(CarSearchModel? model);
        bool Create(CarBindingModel model);
        bool Update(CarBindingModel model);
        bool Delete(CarBindingModel model);
    }
}
