using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
        [HttpPost ("add")]
        public void PostDepartment (Department value) {
            var Entity = new Department () {
                Name = value.Name,
                Budget = value.Budget,
                StartDate = value.StartDate,
                InstructorId = value.InstructorId
            };

            SqlParameter Name = new SqlParameter ("@Name", Entity.Name);
            SqlParameter Budget = new SqlParameter ("@Budget", Entity.Budget);
            SqlParameter StartDate = new SqlParameter ("@StartDate", Entity.StartDate);
            SqlParameter InstructorId = new SqlParameter ("@InstructorId", Entity.InstructorId);
            db.Database.ExecuteSqlRaw (" exec Department_Insert @Name,@Budget, @StartDate ,@InstructorId", Name, Budget, StartDate, InstructorId);

        }

        // PUT api/department/5
        [HttpPut ("{id}")]
        public void PutDepartment (int id, Department value) {
            // var Entitiy = db.Department.Find (id);
            // Entitiy.Name = value.Name;
            // Entitiy.Budget = value.Budget;
            // Entitiy.StartDate = value.StartDate;
            // Entitiy.InstructorId = value.InstructorId;
            // db.SaveChanges();

            var model = db.Department.Find(id);
            var Entity = new Department () {
                DepartmentId = id,
                Name = value.Name,
                Budget = value.Budget,
                StartDate = value.StartDate,
                InstructorId = value.InstructorId,
                RowVersion= model.RowVersion
            };
            
            SqlParameter DepartmentId = new SqlParameter ("@DepartmentID", Entity.DepartmentId);
            SqlParameter Name = new SqlParameter ("@Name", Entity.Name);
            SqlParameter Budget = new SqlParameter ("@Budget", Entity.Budget);
            SqlParameter StartDate = new SqlParameter ("@StartDate", Entity.StartDate);
            SqlParameter InstructorId = new SqlParameter ("@InstructorId", Entity.InstructorId);
            SqlParameter RowVersion_Original = new SqlParameter ("@RowVersion_Original", Entity.RowVersion);
            db.Database.ExecuteSqlRaw (" exec Department_Update @DepartmentID,@Name,@Budget, @StartDate ,@InstructorId,@RowVersion_Original", 
                                            DepartmentId,Name, Budget, StartDate, InstructorId,RowVersion_Original);

        }

        // DELETE api/department/5
        [HttpDelete ("{id}")]
        public void DeleteDepartmentById (int id) {
            var Entity = db.Department.Find (id);
            // db.Department.Remove (model);
            // db.SaveChanges ();

            SqlParameter departmentID = new SqlParameter ("@DepartmentID", Entity.DepartmentId);
            SqlParameter rowVersion_Original = new SqlParameter ("@RowVersion_Original", Entity.RowVersion);

            db.Database.ExecuteSqlRaw (" exec Department_Delete @DepartmentID, @RowVersion_Original", departmentID, rowVersion_Original);

        }
    }
}