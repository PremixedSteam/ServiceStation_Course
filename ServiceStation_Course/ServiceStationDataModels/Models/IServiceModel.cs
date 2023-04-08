namespace ServiceStationDataModels.Models
{
    public interface IServiceModel : IId
    {
        string ServiceDescription { get; }
    }
}
