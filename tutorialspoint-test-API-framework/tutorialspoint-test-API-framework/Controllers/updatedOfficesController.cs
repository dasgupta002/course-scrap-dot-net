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
using tutorialspoint_test_API_framework.Data;
using tutorialspoint_test_API_framework.Models;

namespace tutorialspoint_test_API_framework.Controllers
{
    public class updatedOfficesController : ApiController
    {
        private tutorialspoint_test_API_frameworkContext db = new tutorialspoint_test_API_frameworkContext();

        // GET: api/updatedOffices
        public IQueryable<updatedOffice> GetupdatedOffices()
        {
            return db.updatedOffices;
        }

        // GET: api/updatedOffices/5
        [ResponseType(typeof(updatedOffice))]
        public async Task<IHttpActionResult> GetupdatedOffice(int id)
        {
            updatedOffice updatedOffice = await db.updatedOffices.FindAsync(id);
            if (updatedOffice == null)
            {
                return NotFound();
            }

            return Ok(updatedOffice);
        }

        // PUT: api/updatedOffices/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutupdatedOffice(int id, updatedOffice updatedOffice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != updatedOffice.ID)
            {
                return BadRequest();
            }

            db.Entry(updatedOffice).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!updatedOfficeExists(id))
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

        // POST: api/updatedOffices
        [ResponseType(typeof(updatedOffice))]
        public async Task<IHttpActionResult> PostupdatedOffice(updatedOffice updatedOffice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.updatedOffices.Add(updatedOffice);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = updatedOffice.ID }, updatedOffice);
        }

        // DELETE: api/updatedOffices/5
        [ResponseType(typeof(updatedOffice))]
        public async Task<IHttpActionResult> DeleteupdatedOffice(int id)
        {
            updatedOffice updatedOffice = await db.updatedOffices.FindAsync(id);
            if (updatedOffice == null)
            {
                return NotFound();
            }

            db.updatedOffices.Remove(updatedOffice);
            await db.SaveChangesAsync();

            return Ok(updatedOffice);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool updatedOfficeExists(int id)
        {
            return db.updatedOffices.Count(e => e.ID == id) > 0;
        }
    }
}