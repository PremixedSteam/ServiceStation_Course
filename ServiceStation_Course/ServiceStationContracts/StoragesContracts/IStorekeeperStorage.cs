using ServiceStationContracts.BindingModels;
using ServiceStationContracts.SearchModels;
using ServiceStationContracts.ViewModels;

namespace ServiceStationContracts.StoragesContracts
{
    public interface IStorekeeperStorage
    {
        List<StorekeeperViewModel> GetFullList();
        List<StorekeeperViewModel> GetFilteredList(StorekeeperSearchModel model);
        StorekeeperViewModel? GetElement(StorekeeperSearchModel model);
        StorekeeperViewModel? Insert(StorekeeperBindingModel model);
        StorekeeperViewModel? Update(StorekeeperBindingModel model);
        StorekeeperViewModel? Delete(StorekeeperBindingModel model);
    }
}
