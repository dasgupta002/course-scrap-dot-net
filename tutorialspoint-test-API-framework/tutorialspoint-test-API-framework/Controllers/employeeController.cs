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
    public class employeeController : ApiController
    {
        private tutorialspoint_test_API_frameworkContext db = new tutorialspoint_test_API_frameworkContext();

        // GET: api/employee
        public IQueryable<employee> Getemployees()
        {
            return db.employees;
        }

        // GET: api/employee/5
        [ResponseType(typeof(employee))]
        public async Task<IHttpActionResult> Getemployee(int id)
        {
            employee employee = await db.employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/employee/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putemployee(int id, employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.ID)
            {
                return BadRequest();
            }

            db.Entry(employee).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!employeeExists(id))
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

        // POST: api/employee
        [ResponseType(typeof(employee))]
        public async Task<IHttpActionResult> Postemployee(employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.employees.Add(employee);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = employee.ID }, employee);
        }

        // DELETE: api/employee/5
        [ResponseType(typeof(employee))]
        public async Task<IHttpActionResult> Deleteemployee(int id)
        {
            employee employee = await db.employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            db.employees.Remove(employee);
            await db.SaveChangesAsync();

            return Ok(employee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool employeeExists(int id)
        {
            return db.employees.Count(e => e.ID == id) > 0;
        }
    }
}