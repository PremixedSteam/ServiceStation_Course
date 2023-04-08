﻿using STODataModels.Models;

namespace ServiceStationContracts.BindingModels
{
    public class EmployerBindingModel : IEmployerModel 
    {
        public int Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
