namespace ServiceStationContracts.ViewModels
{
    public class ReportViewModel
    {
        public double Cost { get; set; }
        public List<string> Cars { get; set; } = new();

        public List<string> Spares { get; set; } = new();
    }
}
