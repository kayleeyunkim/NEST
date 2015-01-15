﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NEST_App.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class VehicleModelContainer : DbContext
    {
        public VehicleModelContainer()
            : base("name=VehicleModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<UAV> UAVs1 { get; set; }
        public virtual DbSet<FlightState> FlightStates { get; set; }
        public virtual DbSet<Configuration> Configurations { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<EquipmentHealth> EquipmentHealths { get; set; }
        public virtual DbSet<NonownshipVehicle> NonownshipVehicles { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Mission> Missions { get; set; }
        public virtual DbSet<Maintenance> Maintenances { get; set; }
        public virtual DbSet<MissionLog> MissionLogs { get; set; }
        public virtual DbSet<MissionLogActivity> MissionLogActivities { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
    }
}
