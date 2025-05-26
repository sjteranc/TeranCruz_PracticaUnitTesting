using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

using BEPractice.Models;
using BEPractice.Services;

namespace BEPractice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public List<Person> GetAll()
        {
            return _personService.GetAll();
        }

        [HttpGet("{id}")]
        public Person GetById(int id)
        {
            return _personService.GetById(id);
        }

        [HttpGet("/is-adult/{id}")]
        public Boolean EvaluatePersonIsAdult(int id)
        {
            return _personService.IsAdult(id);
        }

        [HttpPost]
        public Person Create(Person person)
        {
            return _personService.Create(person);
        }

        [HttpPut("{id}")]
        public Person Update(int id, Person updatedPerson)
        {
            return _personService.Update(id, updatedPerson);
        }

        [HttpDelete("{id}")]
        public Person Delete(int id)
        {
            return _personService.Delete(id);
        }
    }
}