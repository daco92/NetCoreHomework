using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreHomework.Models;

namespace NetCoreHomework.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class CourseInstructorController : ControllerBase {
        private readonly ContosouniversityContext db;

        public CourseInstructorController (ContosouniversityContext db) {
            this.db = db;
        }

        // GET api/courseinstructor
        [HttpGet ("")]
        public ActionResult<IEnumerable<CourseInstructor>> GetCoureseInstructors () {
            return db.CourseInstructor.ToList ();
        }

        // GET api/courseinstructor/5
        [HttpGet ("{cid}/{iid}")]
        public ActionResult<CourseInstructor> GetCoureseInstructorById (int cid,int iid) {
            return db.CourseInstructor.Find(cid,iid);
        }

        // POST api/courseinstructor
        [HttpPost ("")]
        public void PostCoureseInstructor (CourseInstructor value) { }

        // PUT api/courseinstructor/5
        [HttpPut ("{cid}/{iid}")]
        public void PutCoureseInstructor (int cid,int iid, CourseInstructor value) {
            // var courseInstructor = db.CourseInstructor.Find(id);
            // courseInstructor.Course = value.Course;
            // courseInstructor.CourseId = value.CourseId;
            // courseInstructor.Instructor = value.Instructor;
            // courseInstructor.InstructorId = value.InstructorId;
            // var courseInstructor = db.CourseInstructor.Find(cid,iid);
            // courseInstructor.CourseId=value.CourseId;
            // courseInstructor.InstructorId=value.InstructorId;
            // db.CourseInstructor.Update(courseInstructor);
            db.SaveChanges ();

        }

        // DELETE api/courseinstructor/5
        [HttpDelete ("{cid}/{iid}")]
        public void DeleteCoureseInstructorById (int cid,int iid) {
            var courseInstructor = db.CourseInstructor.Find (cid,iid);
            db.CourseInstructor.Remove (courseInstructor);
            db.SaveChanges ();

        }
    }
}