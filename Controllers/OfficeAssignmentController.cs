using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreHomework.Models;

namespace NetCoreHomework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeAssignmentController : ControllerBase
    {
        private readonly ContosouniversityContext db;
        public OfficeAssignmentController(ContosouniversityContext db)
        {
            this.db = db;
        }

        // GET api/officeassignment
        [HttpGet("")]
        public ActionResult<IEnumerable<OfficeAssignment>> GetOfficeAssignments()
        {
            return db.OfficeAssignment.ToList();
        }

        // GET api/officeassignment/5
        [HttpGet("{id}")]
        public ActionResult<OfficeAssignment> GetOfficeAssignmentById(int id)
        {
            return db.OfficeAssignment.Find(id);
        }

        // POST api/officeassignment
        [HttpPost("")]
        public void PostOfficeAssignment(OfficeAssignment value)
        {
        }

        // PUT api/officeassignment/5
        [HttpPut("{id}")]
        public void PutOfficeAssignment(int id, OfficeAssignment value)
        {
        }

        // DELETE api/officeassignment/5
        [HttpDelete("{id}")]
        public void DeleteOfficeAssignmentById(int id)
        {
            var model = db.OfficeAssignment.Find(id);
            db.OfficeAssignment.Remove(model);
            db.SaveChanges();
        }
    }
}