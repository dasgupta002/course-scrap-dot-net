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
using Caching;

namespace tutorialspoint_test_API_framework.Controllers
{
    public class officeController : ApiController
    {
        private tutorialspoint_test_API_frameworkContext db = new tutorialspoint_test_API_frameworkContext();

        // GET: api/office
        
        [cacheFilter(duration = 300)]
        public IQueryable<officeDTO> Getoffices()
        {
            var offices = from x in db.offices
                          select new officeDTO()
                          {
                              ID = x.ID,
                              employeeName = x.emp.name
                          };
            return offices;
        }

        // GET: api/office/5
        [ResponseType(typeof(officedetailDTO))]
        public async Task<IHttpActionResult> Getoffice(int id)
        {
            var office = await db.offices.Include(x => x.emp).Select(
                x => new officedetailDTO() { 
                   ID = x.ID,
                   location = x.location,
                   employeeName = x.emp.name
                }).SingleOrDefaultAsync(b => b.ID == id);
            
            if (office == null)
            {
                return NotFound();
            }

            return Ok(office);
        }

        // PUT: api/office/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putoffice(int id, office office)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != office.ID)
            {
                return BadRequest();
            }

            db.Entry(office).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!officeExists(id))
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

        // POST: api/office
        [ResponseType(typeof(office))]
        public async Task<IHttpActionResult> Postoffice(office office)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.offices.Add(office);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = office.ID }, office);
        }

        // DELETE: api/office/5
        [ResponseType(typeof(office))]
        public async Task<IHttpActionResult> Deleteoffice(int id)
        {
            office office = await db.offices.FindAsync(id);
            if (office == null)
            {
                return NotFound();
            }

            db.offices.Remove(office);
            await db.SaveChangesAsync();

            return Ok(office);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool officeExists(int id)
        {
            return db.offices.Count(e => e.ID == id) > 0;
        }
    }
}