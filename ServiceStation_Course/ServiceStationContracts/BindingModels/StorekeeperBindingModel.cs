using ServiceStationDataModels.Models;

namespace ServiceStationContracts.BindingModels
{
    public class StorekeeperBindingModel : IStorekeeperModel
    {
        public int Id { get; set; }

        public string Login { get; set; } = String.Empty;

        public string Password { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;
    }
}
