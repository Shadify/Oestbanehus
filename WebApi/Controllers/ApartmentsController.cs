﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApi.Models
{

    public class BuildingDto
    {
        public int Id { get; set; }
        public int Floor { get; set; }
        public string Genre { get; set; }
    }



    [RoutePrefix("api/Apartments")]
    public class ApartmentsController : ApiController
    {
        private Context db = new Context();

        // GET: api/Apartments
        public IQueryable<Apartment> GetApartments()
        {
            return db.Apartments;
        }

        [Route("{id:int}/buildingAps")]
        public IQueryable<Apartment> GetBuildingApartments(int id)
        {
            var buildingAps = (from ap in db.Apartments
                               where ap.BuildingId == id
                               select ap);

            return buildingAps;
        }

        // GET: api/Apartments/5
        [ResponseType(typeof(Apartment))]
        public IHttpActionResult GetApartment(int id)
        {
            Apartment apartment = db.Apartments.Find(id);
            if (apartment == null)
            {
                return NotFound();
            }

            return Ok(apartment);
        }

        // PUT: api/Apartments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutApartment(int id, Apartment apartment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != apartment.Id)
            {
                return BadRequest();
            }

            db.Entry(apartment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApartmentExists(id))
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

        // POST: api/Apartments
        [ResponseType(typeof(Apartment))]
        public IHttpActionResult PostApartment(Apartment apartment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Apartments.Add(apartment);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ApartmentExists(apartment.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = apartment.Id }, apartment);
        }

        // DELETE: api/Apartments/5
        [ResponseType(typeof(Apartment))]
        public IHttpActionResult DeleteApartment(int id)
        {
            Apartment apartment = db.Apartments.Find(id);
            if (apartment == null)
            {
                return NotFound();
            }

            db.Apartments.Remove(apartment);
            db.SaveChanges();

            return Ok(apartment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApartmentExists(int id)
        {
            return db.Apartments.Count(e => e.Id == id) > 0;
        }
    }
}