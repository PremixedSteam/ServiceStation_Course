﻿using Microsoft.EntityFrameworkCore;
using ServiceStationDatabaseImplement.Models;

namespace ServiceStationDatabaseImplement
{
	public class ServiceStationDatabase : DbContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
				optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-QVK6NSA\SQLEXPRESS03;Initial Catalog=ServiceStation;Integrated Security=True;TrustServerCertificate=True"); 
			}
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Car> Cars { set; get; }
        public virtual DbSet<CarSpare> CarSpares { set; get; }
        public virtual DbSet<Employer> Employers { set; get; }
        public virtual DbSet<Maintenance> Maintenances { set; get; }
        public virtual DbSet<MaintenanceCar> MaintenanceCars { set; get; }
        public virtual DbSet<Service> Services { set; get; }
        public virtual DbSet<Spare> Spares { set; get; }
        public virtual DbSet<Storekeeper> Storekeepers  { set; get; }
        public virtual DbSet<Work> Works { set; get; }
        public virtual DbSet<WorkDuration> WorkDurations { set; get; }
        public virtual DbSet<WorkMaintence> WorkMaintences { set; get; }
        public virtual DbSet<WorkSpare> WorkSpares { set; get; }

    }
}
