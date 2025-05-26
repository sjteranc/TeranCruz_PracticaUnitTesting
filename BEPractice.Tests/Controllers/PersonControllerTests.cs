using Xunit;
using Moq;
using BEPractice.Models;
using BEPractice.Services;
using BEPractice.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace BEPractice.Tests.Controllers
{
    public class PersonControllerTests
    {
        [Fact]
        public void GetAll_WithMock_ReturnsAllPersons()
        {
            var persons = new List<Person>
            {
                new Person { CI = 1, Nombre = "Juan Pérez" },
                new Person { CI = 2, Nombre = "María Rodríguez" }
            };

            var mockService = new Mock<IPersonService>();
            mockService.Setup(x => x.GetAll()).Returns(persons);
            var controller = new PersonController(mockService.Object);

            var result = controller.GetAll();

            Assert.Equal(persons, result);
        }

        [Fact]
        public void GetById_WithMock_ReturnsCorrectPerson()
        {
            var person = new Person { CI = 1, Nombre = "Juan Pérez" };
            var mockService = new Mock<IPersonService>();
            mockService.Setup(x => x.GetById(1)).Returns(person);
            var controller = new PersonController(mockService.Object);

            var result = controller.GetById(1);

            Assert.Equal(person, result);
        }

        [Fact]
        public void Create_WithMock_ReturnsCreatedPerson()
        {
            var person = new Person { CI = 3, Nombre = "Carlos González" };
            var mockService = new Mock<IPersonService>();
            mockService.Setup(x => x.Create(person)).Returns(person);
            var controller = new PersonController(mockService.Object);

            var result = controller.Create(person);

            Assert.Equal(person, result);
        }
    }

    public class StubPersonService : IPersonService
    {
        private readonly List<Person> _persons;
        private readonly Person? _personById;
        private readonly Person? _createdPerson;

        public StubPersonService(List<Person> persons, Person? personById = null, Person? createdPerson = null)
        {
            _persons = persons;
            _personById = personById;
            _createdPerson = createdPerson;
        }

        public List<Person> GetAll()
        {
            return _persons;
        }

        public Person GetById(int id)
        {
            return _personById ?? new Person { CI = id, Nombre = "Persona por defecto" };
        }

        public bool IsAdult(int id)
        {
            return true;
        }

        public Person Create(Person person)
        {
            return _createdPerson ?? person;
        }

        public Person Update(int id, Person updatedPerson)
        {
            return updatedPerson;
        }

        public Person Delete(int id)
        {
            return new Person { CI = id, Nombre = "Persona eliminada" };
        }
    }

    public class PersonControllerStubTests
    {
        [Fact]
        public void GetAll_WithStub_ReturnsAllPersons()
        {
            var persons = new List<Person>
            {
                new Person { CI = 1, Nombre = "Juan Pérez" },
                new Person { CI = 2, Nombre = "María Rodríguez" }
            };

            var stubService = new StubPersonService(persons);
            var controller = new PersonController(stubService);

            var result = controller.GetAll();

            Assert.Equal(persons, result);
        }

        [Fact]
        public void GetById_WithStub_ReturnsCorrectPerson()
        {
            var person = new Person { CI = 1, Nombre = "Juan Pérez" };
            var stubService = new StubPersonService(new List<Person>(), person);
            var controller = new PersonController(stubService);

            var result = controller.GetById(1);

            Assert.Equal(person, result);
        }

        [Fact]
        public void Create_WithStub_ReturnsCreatedPerson()
        {
            var person = new Person { CI = 3, Nombre = "Carlos González" };
            var stubService = new StubPersonService(new List<Person>(), createdPerson: person);
            var controller = new PersonController(stubService);

            var result = controller.Create(person);

            Assert.Equal(person, result);
        }
    }
}


