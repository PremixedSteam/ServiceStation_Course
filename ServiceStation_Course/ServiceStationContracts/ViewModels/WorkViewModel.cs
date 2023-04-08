﻿using ServiceStationDataModels.Models;
using System.ComponentModel;

namespace ServiceStationContracts.ViewModels
{
    public class WorkViewModel : IWorkModel
    {
        public int Id { get; set; }
        [DisplayName("Название")]
        public string Title { get; set; } = String.Empty;
        [DisplayName("Цена")]
        public double Price { get; set; }
        public int DurationId { get; set; }
        public int StorekeeperId { get; set; }

        public Dictionary<int, (ISpareModel, int)> WorkSpares { get; set; } = new();

        public Dictionary<int, (IMaintenanceModel, int)> WorkMaintences { get; set; } = new();

        
    }
}
