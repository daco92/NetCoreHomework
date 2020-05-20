using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreHomework.Models;

namespace NetCoreHomework.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase {
        private readonly ContosouniversityContext db;
        public EnrollmentController (ContosouniversityContext db) {
            this.db = db;
        }

        // GET api/enrollment
        [HttpGet ("")]
        public ActionResult<IEnumerable<Enrollment>> GetEnrollments () {
            return db.Enrollment.ToList();
        }

        // GET api/enrollment/5
        [HttpGet ("{id}")]
        public ActionResult<Enrollment> GetEnrollmentById (int id) {
            return db.Enrollment.Find(id);
        }

        // POST api/enrollment
        [HttpPost ("add")]
        public ActionResult<IEnumerable<Enrollment>> PostEnrollment (Enrollment value) { 
            var model = new Enrollment(){
                CourseId=value.CourseId,
                StudentId=value.StudentId,
                Grade=value.Grade
            };

            db.Enrollment.Add(model);
            db.SaveChanges();
            
            return Created ("/api/Enrollment/" + model.CourseId, model);

        }

        // PUT api/enrollment/5
        [HttpPut ("{id}")]
        public void PutEnrollment (int id, Enrollment value) { }

        // DELETE api/enrollment/5
        [HttpDelete ("{id}")]
        public void DeleteEnrollmentById (int id) {
            var model = db.Enrollment.Find(id);
            db.Enrollment.Remove(model);
            db.SaveChanges();
         }
    }
}