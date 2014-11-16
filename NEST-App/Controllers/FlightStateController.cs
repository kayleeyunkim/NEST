﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using NEST_App.DAL;
using NEST_App.Models;

namespace NEST_App.Controllers
{
    public class FlightStateController : ApiController
    {
        private NestDbContext db = new NestDbContext();

        // GET: api/FlightState
        public IQueryable<FlightStateDTO> GetFlightStates()
        {
            var flightStates = from fs in db.FlightStates
                               select new FlightStateDTO()
                               {
                                   Id = fs.Id,
                                   Timestamp = fs.Timestamp,
                                   Latitude = fs.Position.Latitude,
                                   Longitude = fs.Position.Longitude,
                                   Altitude = fs.Position.Elevation,
                                   VelocityX = fs.VelocityX,
                                   VelocityY = fs.VelocityY,
                                   VelocityZ = fs.VelocityZ,
                                   Yaw = fs.Yaw,
                                   Roll = fs.Roll,
                                   Pitch = fs.Pitch,
                                   YawRate = fs.YawRate,
                                   RollRate = fs.RollRate,
                                   PitchRate = fs.PitchRate,
                                   BatteryLevel = fs.BatteryLevel
                               };
            return flightStates;
        }

        // GET: api/FlightState/5
        [ResponseType(typeof(FlightStateDTO))]
        public async Task<IHttpActionResult> GetFlightState(int id)
        {
            FlightState flightState = await db.FlightStates.FindAsync(id);
            if (flightState == null)
            {
                return NotFound();
            }

            FlightStateDTO dto = new FlightStateDTO();
            dto.buildDTO(flightState);

            return Ok(dto);
        }

        // PUT: api/FlightState/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFlightState(int id, FlightState flightState)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != flightState.Id)
            {
                return BadRequest();
            }

            db.Entry(flightState).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightStateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/FlightState
        [ResponseType(typeof(FlightState))]
        public async Task<IHttpActionResult> PostFlightState(FlightState flightState)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FlightStates.Add(flightState);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = flightState.Id }, flightState);
        }

        // DELETE: api/FlightState/5
        [ResponseType(typeof(FlightState))]
        public async Task<IHttpActionResult> DeleteFlightState(int id)
        {
            FlightState flightState = await db.FlightStates.FindAsync(id);
            if (flightState == null)
            {
                return NotFound();
            }

            db.FlightStates.Remove(flightState);
            await db.SaveChangesAsync();

            return Ok(flightState);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FlightStateExists(int id)
        {
            return db.FlightStates.Count(e => e.Id == id) > 0;
        }
    }
}