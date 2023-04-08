using ServiceStationDataModels.Models;
using System.ComponentModel;

namespace ServiceStationContracts.ViewModels
{
    public class EmployerViewModel : IEmployerModel
    {
        public int Id { get; set; }
        [DisplayName("Логин")]
        public string Login { get; set; } = string.Empty;
        [DisplayName("Пароль")]
        public string Password { get; set; } = string.Empty;
        [DisplayName("Почта")]
        public string Email { get; set; } = string.Empty;
    }
}
