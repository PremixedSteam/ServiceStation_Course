namespace ServiceStationDataModels.Models
{
    public interface ISpareModel : IId
    {
        string Name { get; }

        double Price { get; }
    }
}
