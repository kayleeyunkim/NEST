﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using NEST_App.Models;

namespace NEST_App.DAL
{
    public class NestDbContext : DbContext
    {

        public NestDbContext() : base("NestDbContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<UAV> OwnshipVehicles { get; set; }
        public DbSet<NonownshipVehicle> NonownshipVehicles { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<Equipment> EquipmentList { get; set; }
        public DbSet<EquipmentHealth> EquipmentHealthList { get; set; }
        public DbSet<FlightState> FlightStates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}