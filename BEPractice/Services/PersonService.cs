using BEPractice.Models;

namespace BEPractice.Services
{
    public class PersonService : IPersonService
    {
        // In-memory list for demonstration purposes
        private List<Person> _persons;

        public PersonService()
        {
            _persons = new List<Person>
            {
                new Person { CI = 1, Nombre = "Juan Pérez" },
                new Person { CI = 2, Nombre = "María Rodríguez" },
                new Person { CI = 3, Nombre = "Carlos González" }
            };
        }

        public List<Person> GetAll()
        {
            return _persons;
        }

        public Person GetById(int id)
        {
            var person = _persons.FirstOrDefault(p => p.CI == id);
            return person ?? new Person { CI = -1, Nombre = string.Empty };
        }

        public Person Create(Person person)
        {
            _persons.Add(person);
            return person;
        }

        public Person Update(int id, Person updatedPerson)
        {
            var person = _persons.FirstOrDefault(p => p.CI == id);
            if (person == null)
                return new Person { CI = -1, Nombre = string.Empty };

            person.Nombre = updatedPerson.Nombre;
            return person;
        }

        public Person Delete(int id)
        {
            var person = _persons.FirstOrDefault(p => p.CI == id);
            if (person == null)
                return new Person { CI = -1, Nombre = string.Empty };

            _persons.Remove(person);
            return person;
        }

        public bool IsAdult(int id)
        {
            // Por ahora retornamos true por defecto ya que no tenemos la propiedad Age
            return true;
        }
    }
}