﻿using ServiceStationContracts.BindingModels;
using ServiceStationContracts.ViewModels;
using ServiceStationDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStationDatabaseImplement.Models
{
    public class WorkDuration : IWorkDurationModel
    {
        public int Id { get; set; }

        [Required]
        public int Duration { get; set; }

        [ForeignKey("DurationId")]
        public virtual List<Work> Works { get; set; }

        public static WorkDuration Create(WorkDurationBindingModel model)
        {
            return new WorkDuration()
            {
                Id = model.Id,
                Duration = model.Duration,
            };
        }
        public void Update(WorkDurationBindingModel model)
        {
            Duration = model.Duration;
        }
        public WorkDurationViewModel GetViewModel => new()
        {
            Id = Id,
            Duration = Duration,
        };
    }
}
