﻿using ServiceStationDataModels.Models;

namespace ServiceStationContracts.SearchModels
{
    public class WorkSearchModel
    {
        public int? Id { get; set; }

        public string? Title { get; set; }

        public double? Price { get; set; }

        public int? StorekeeperId { get; set; }

        public int? DurationId { get; set; }

        public Dictionary<int, (ISpareModel, int)>? WorkSpares { get; set; }

        public Dictionary<int, (IMaintenanceModel, int)>? WorkMaintenances { get; set; }
    }
}
