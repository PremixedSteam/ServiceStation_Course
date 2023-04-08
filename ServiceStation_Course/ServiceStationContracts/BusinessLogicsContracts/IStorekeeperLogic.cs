using ServiceStationContracts.BindingModels;
using ServiceStationContracts.SearchModels;
using ServiceStationContracts.ViewModels;

namespace ServiceStationContracts.BusinessLogicsContracts
{
    public interface IStorekeeperLogic
    {
        List<StorekeeperViewModel>? ReadList(StorekeeperSearchModel? model);
        StorekeeperViewModel? ReadElement(StorekeeperSearchModel? model);
        bool Create(StorekeeperBindingModel model);
        bool Update(StorekeeperBindingModel model);
        bool Delete(StorekeeperBindingModel model);
    }
}
