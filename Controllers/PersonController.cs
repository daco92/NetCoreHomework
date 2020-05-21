using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreHomework.Models;

namespace NetCoreHomework.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase {
        private readonly ContosouniversityContext db;
        public PersonController (ContosouniversityContext db) {
            this.db = db;
        }

        // GET api/person
        [HttpGet ("")]
        public ActionResult<IEnumerable<Person>> GetPersons () {
            return db.Person.ToList ();
        }

        // GET api/person/5
        [HttpGet ("{id}")]
        public ActionResult<Person> GetPersonById (int id) {
            return db.Person.Find (id);
        }

        [HttpPost ("add")]
        public ActionResult<IEnumerable<Enrollment>> PostAddPersion (Person value) {
            var model = new Person () {
                LastName = value.LastName,
                FirstName = value.FirstName,
                Discriminator = value.Discriminator

            };

            db.Person.Add (model);
            db.SaveChanges ();
            return Created ("/api/Person/" + model.Id, model);
        }

        // POST api/person
        [HttpPost ("")]
        public void PostPerson (Person value) { }

        // PUT api/person/5
        [HttpPut ("{id}")]
        public void PutPerson (int id, Person value) {
            var model = db.Person.Find(id);
            model.LastName = value.LastName;
            db.SaveChanges();


         }

        // DELETE api/person/5
        [HttpDelete ("{id}")]
        public void DeletePersonById (int id) {

            var model = db.Person.Find(id);
            db.Person.Remove(model);
            db.SaveChanges();

         }
    }
}