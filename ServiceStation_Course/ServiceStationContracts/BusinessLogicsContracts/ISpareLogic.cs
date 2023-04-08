using ServiceStationContracts.BindingModels;
using ServiceStationContracts.SearchModels;
using ServiceStationContracts.ViewModels;

namespace ServiceStationContracts.BusinessLogicsContracts
{
    public interface ISpareLogic
    {
        List<SpareViewModel>? ReadList(SpareSearchModel? model);
        SpareViewModel? ReadElement(SpareSearchModel? model);
        bool Create(SpareBindingModel model);
        bool Update(SpareBindingModel model);
        bool Delete(SpareBindingModel model);
    }
}
