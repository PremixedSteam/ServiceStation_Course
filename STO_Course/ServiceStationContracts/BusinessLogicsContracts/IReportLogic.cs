using ServiceStationContracts.BindingModels;
using ServiceStationContracts.ViewModels;

namespace ServiceStationContracts.BusinessLogicsContracts
{
    public interface IReportLogic
    {
        List<ReportViewModel> GetCarsAndSpares(ReportBindingModel model);
        void SaveToWordFile(ReportBindingModel model);
        void SaveToExcelFile(ReportBindingModel model);
        void SaveToPdfFile(ReportBindingModel model);
    }
}
