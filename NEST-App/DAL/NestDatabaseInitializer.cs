﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NEST_App.Models;
using System.Data.Entity.Spatial;
using System.Data;
using System.Data.Entity.Validation;

namespace NEST_App.DAL
{
    public class NestDatabaseInitializer : System.Data.Entity.DropCreateDatabaseAlways<VehicleModelContainer>
    {
        public void InitializeDatabase()
        {
            Seed(new VehicleModelContainer());
        }
        protected override void Seed(VehicleModelContainer context)
        {
            // We can initialize everything here and store it into the database
           var UAVs = new List<UAV>
            {
                new UAV{Callsign = "HAWK21", NumDeliveries = 2134, Mileage = 234, Id = 0, create_date = DateTime.Now, modified_date = DateTime.Now},
                //new UAV{Callsign = "CROW10", NumDeliveries = 1234, Mileage = 111, Id = 1},
                //new UAV{Callsign = "PINR44", NumDeliveries = 3301, Mileage = 044, Id = 2},
                //new UAV{Callsign = "BIRD00", NumDeliveries = 2215, Mileage = 591, Id = 3}
            };
            UAVs.ForEach(s => context.UAVs1.Add(s));

            var FlightStates = new List<FlightState>
            {
                new FlightState{ Position = DbGeography.FromText("POINT(-118.529 34.2417 400)"), VelocityX = 0, VelocityY = 0, VelocityZ = 0, Yaw = 0, Roll = 0, Pitch = 0, YawRate = 0, RollRate = 0, PitchRate = 0, BatteryLevel = .94, UAVId = 0 },
                //new FlightState{ Position = DbGeography.FromText("POINT(-118.5002736 34.2365205 400)"), VelocityX = 0, VelocityY = 0, VelocityZ = 0, Yaw = 0, Roll = 0, Pitch = 0, YawRate = 0, RollRate = 0, PitchRate = 0, BatteryLevel = .84, UAVId = 1 },
                //new FlightState{ Position = DbGeography.FromText("POINT(-118.5002736 34.2365205 400)"), VelocityX = 0, VelocityY = 0, VelocityZ = 0, Yaw = 0, Roll = 0, Pitch = 0, YawRate = 0, RollRate = 0, PitchRate = 0, BatteryLevel = .82, UAVId = 2 },
                //new FlightState{ Position = DbGeography.FromText("POINT(-118.5002736 34.2365205 400)"), VelocityX = 0, VelocityY = 0, VelocityZ = 0, Yaw = 0, Roll = 0, Pitch = 0, YawRate = 0, RollRate = 0, PitchRate = 0, BatteryLevel = .74, UAVId = 3 }


                //new FlightState{ Position = DbGeography.FromText("POINT(-118.529 34.2417 400)"), VelocityX = 0, VelocityY = 0, VelocityZ = 0, Yaw = 0, Roll = 0, Pitch = 0, YawRate = 0, RollRate = 0, PitchRate = 0, BatteryLevel = .94, UAVId = 0 },
                //new FlightState{ Position = DbGeography.FromText("POINT(-118.529 34.2417 400)"), VelocityX = 0, VelocityY = 0, VelocityZ = 0, Yaw = 0, Roll = 0, Pitch = 0, YawRate = 0, RollRate = 0, PitchRate = 0, BatteryLevel = .84, UAVId = 1 },
                //new FlightState{ Position = DbGeography.FromText("POINT(-118.529 34.2417 400)"), VelocityX = 0, VelocityY = 0, VelocityZ = 0, Yaw = 0, Roll = 0, Pitch = 0, YawRate = 0, RollRate = 0, PitchRate = 0, BatteryLevel = .82, UAVId = 2 },
                //new FlightState{ Position = DbGeography.FromText("POINT(-118.529 34.2417 400)"), VelocityX = 0, VelocityY = 0, VelocityZ = 0, Yaw = 0, Roll = 0, Pitch = 0, YawRate = 0, RollRate = 0, PitchRate = 0, BatteryLevel = .74, UAVId = 3 }
            };
            FlightStates.ForEach(s =>
            {
                s.Timestamp = DateTime.Now;
                context.FlightStates.Add(s);
                s.create_date = DateTime.Now;
                s.modified_date = DateTime.Now;
            });
            DateTime dateValue = new DateTime();
            dateValue = DateTime.Now;
            var missions = new List<Mission>
            {
                new Mission{Phase = "enroute", FlightPattern = "abstract", Payload = "cheetos", Priority = 1, FinancialCost = 40, TimeAssigned = dateValue, TimeCompleted = dateValue.AddHours(0.0833), DestinationCoordinates = DbGeography.FromText("POINT(-118.4902736 34.2365205 400)"),  ScheduledCompletionTime = dateValue.AddHours(0.0899), EstimatedCompletionTime = dateValue.AddHours(0.09), create_date = dateValue.AddHours(0.01), modified_date = dateValue.AddHours(0.02) },
                //new Mission{Phase = "enroute", FlightPattern = "abstract", Payload = "cheetos", Priority = 1, FinancialCost = 40, TimeAssigned = DateTime.Now, TimeCompleted = dateValue.AddHours(0.0833), DestinationCoordinates = DbGeography.FromText("POINT(-118.4502736 34.2965205 400)"),  ScheduledCompletionTime = dateValue.AddHours(0.0899), EstimatedCompletionTime = dateValue.AddHours(0.09)  }

            };
            //missions.ForEach(s => context.Missions.Add(s));

            var schedules = new List<Schedule>
            { 
                new Schedule{
                    UAV = UAVs[0],
                    create_date = DateTime.Now,
                    modified_date = DateTime.Now,
                    //Maintenances = new List<Maintenance>{
                    //    new Maintenance{ create_date = DateTime.Now,
                    //    modified_date = DateTime.Now,
                    //    last_maintenance = DateTime.Now,
                    //    next_maintenance = DateTime.Now,
                    //    }
                    //},
            Missions = missions
                }
                
            };
            schedules.ForEach(s => context.Schedules.Add(s));

            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}