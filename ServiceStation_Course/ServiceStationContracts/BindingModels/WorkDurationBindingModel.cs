using ServiceStationDataModels.Models;

namespace ServiceStationContracts.BindingModels
{
    public class WorkDurationBindingModel : IWorkDurationModel
    {
        public int Id { get; set; }

        public int Duration { get; set; }
    }
}
