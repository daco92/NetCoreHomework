using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreHomework.Models;

namespace NetCoreHomework.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase {
        private readonly ContosouniversityContext db;
        public DepartmentController (ContosouniversityContext db) {
            this.db = db;
        }

        // GET api/department
        [HttpGet ("")]
        public ActionResult<IEnumerable<Department>> GetDepartments () {
            return db.Department.ToList ();
        }

        // GET api/department/5
        [HttpGet ("{id}")]
        public ActionResult<Department> GetDepartmentById (int id) {
            return db.Department.Find (id);
        }

        [HttpGet ("add")]
        public ActionResult<Department> AddDepartment () {
            var model = new Department () {
                Name = "Core訓練部",
                Budget = 1000,
                StartDate = DateTime.Parse ("2019/3/1"),
                InstructorId = 3
            };
            db.Department.Add (model);
            db.SaveChanges ();

            return Created ("/api/department/" + model.DepartmentId, model);

        }

        // POST api/department
        [HttpPost ("")]
        public void PostDepartment (Department value) { }

        // PUT api/department/5
        [HttpPut ("{id}")]
        public void PutDepartment (int id, Department value) { }

        // DELETE api/department/5
        [HttpDelete ("{id}")]
        public void DeleteDepartmentById (int id) {
            var model = db.Department.Find (id);
            db.Department.Remove (model);
            db.SaveChanges ();
        }
    }
}