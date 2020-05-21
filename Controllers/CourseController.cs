using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreHomework.Models;
//using NetCoreHomework.Models;

namespace NetCoreHomework.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase {
        private readonly ContosouniversityContext db;
        public CourseController (ContosouniversityContext db) {
            this.db = db;
        }

        // GET api/course
        [HttpGet ("")]
        public ActionResult<IEnumerable<Course>> GetCourses () {

            return db.Course.ToList ();
        }

        // GET api/course
        [HttpGet ("CourseStudentsCount")]
        public ActionResult<IEnumerable<VwCourseStudentCount>> GetCourseStudentCount () {

            var model = db.VwCourseStudentCount
                .FromSqlRaw ("Select * from VwCourseStudentCount")
                .ToList ();

            return model;
        }

        // GET api/course
        [HttpGet ("CourseStudents")]
        public ActionResult<IEnumerable<VwCourseStudents>> GetCourseStudents () {

            return db.VwCourseStudents.ToList ();
        }

        // GET api/course/5
        [HttpGet ("{id}")]
        public ActionResult<Course> GetCourseById (int id) {
            return db.Course.Find (id);
        }

        [HttpGet ("add")]
        public ActionResult<Course> add () {
            var course = new Course () {
                Title = "Core的第一本書",
                Credits = 3,
                DepartmentId = 5

            };
            db.Course.Add (course);
            db.SaveChanges ();

            return Created ("/api/course/" + course.CourseId, course);
        }

        // POST api/course
        [HttpPost ("")]
        public void PostCourse (Course value) { }

        // PUT api/course/5
        [HttpPut ("{id}")]
        public void PutCourse (int id, Course value) {
            var course = db.Course.Find (id);
            course.Title = value.Title;
            db.SaveChanges ();

        }

        // DELETE api/course/5
        [HttpDelete ("{id}")]
        public void DeleteCourseById (int id) {
            var course = db.Course.Find (id);
            db.Course.Remove (course);
            db.SaveChanges ();
        }
    }
}