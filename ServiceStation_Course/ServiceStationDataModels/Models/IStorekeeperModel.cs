namespace ServiceStationDataModels.Models
{
    public interface IStorekeeperModel : IId
    {
        string Login { get; }

        string Password { get; }
        string Email { get; }
    }
}
