﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ServiceStationDatabaseImplement.Models
{
    public class MaintenanceCar
    {
        public int Id { get; set; }

        [Required]
        public int MaintenanceId { get; set; }

        [Required]
        public int CarId { get; set; }
        [Required]
        public int Count { get; set; }

        public virtual Car Car { get; set; } = new();

        public virtual Maintenance Maintenance { get; set; } = new();
    }
}
