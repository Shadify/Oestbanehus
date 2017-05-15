using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class BuildingsController : ApiController
    {
        private ViewContext db = new ViewContext();

        // GET: api/Buildings
        public IQueryable<Building> GetBuildings()
        {
            return db.Buildings;
        }

        // GET: api/Buildings/5
        [ResponseType(typeof(Building))]
        public IHttpActionResult GetBuilding(int id)
        {
            Building building = db.Buildings.Find(id);
            if (building == null)
            {
                return NotFound();
            }

            return Ok(building);
        }

        // PUT: api/Buildings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBuilding(int id, Building building)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != building.Id)
            {
                return BadRequest();
            }

            db.Entry(building).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuildingExists(id))
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

        // POST: api/Buildings
        [ResponseType(typeof(Building))]
        public IHttpActionResult PostBuilding(Building building)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Buildings.Add(building);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (BuildingExists(building.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = building.Id }, building);
        }

        // DELETE: api/Buildings/5
        [ResponseType(typeof(Building))]
        public IHttpActionResult DeleteBuilding(int id)
        {
            Building building = db.Buildings.Find(id);
            if (building == null)
            {
                return NotFound();
            }

            db.Buildings.Remove(building);
            db.SaveChanges();

            return Ok(building);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BuildingExists(int id)
        {
            return db.Buildings.Count(e => e.Id == id) > 0;
        }
    }
}