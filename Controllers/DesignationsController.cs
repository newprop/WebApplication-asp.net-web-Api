using System;
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
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class DesignationsController : ApiController
    {
        private Employeedb db = new Employeedb();

        // GET: api/Designations
        public IQueryable<Designation> GetDesignations()
        {
            return db.Designations;
        }

        // GET: api/Designations/5
        [ResponseType(typeof(Designation))]
        public async Task<IHttpActionResult> GetDesignation(int id)
        {
            Designation designation = await db.Designations.FindAsync(id);
            if (designation == null)
            {
                return NotFound();
            }

            return Ok(designation);
        }

        // PUT: api/Designations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDesignation(int id, Designation designation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != designation.Id)
            {
                return BadRequest();
            }

            db.Entry(designation).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesignationExists(id))
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

        // POST: api/Designations
        [ResponseType(typeof(Designation))]
        public async Task<IHttpActionResult> PostDesignation(Designation designation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Designations.Add(designation);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = designation.Id }, designation);
        }

        // DELETE: api/Designations/5
        [ResponseType(typeof(Designation))]
        public async Task<IHttpActionResult> DeleteDesignation(int id)
        {
            Designation designation = await db.Designations.FindAsync(id);
            if (designation == null)
            {
                return NotFound();
            }

            db.Designations.Remove(designation);
            await db.SaveChangesAsync();

            return Ok(designation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DesignationExists(int id)
        {
            return db.Designations.Count(e => e.Id == id) > 0;
        }
    }
}