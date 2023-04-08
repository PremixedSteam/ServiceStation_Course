using ServiceStationDataModels.Models;

namespace ServiceStationContracts.BindingModels
{
    public class ServiceBindingModel : IServiceModel
    {
        public int Id { get; set; }
        public string ServiceDescription { get; set; }=string.Empty;
    }
}
