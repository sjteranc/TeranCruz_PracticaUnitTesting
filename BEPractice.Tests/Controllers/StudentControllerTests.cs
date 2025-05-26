using Xunit;
using Moq;
using BEPractice.Models;
using BEPractice.Services;
using BEPractice.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace BEPractice.Tests.Controllers
{
    /// <summary>
    /// Pruebas unitarias para el StudentController.
    /// Estas pruebas verifican el comportamiento del controlador usando mocks y stubs.
    /// </summary>
    public class StudentControllerTests
    {
        [Fact]
        public void CheckApproval_WithMock_ReturnsCorrectResult()
        {
            var mockService = new Mock<IStudentService>();
            mockService.Setup(x => x.HasApproved(123)).Returns(true);
            var controller = new StudentController(mockService.Object);

            var result = controller.CheckApproval(123);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
            Assert.True((bool)okResult.Value!);
        }

        [Fact]
        public void GetStudent_WithMock_ReturnsCorrectStudent()
        {
            var student = new Estudiante { CI = 123, Nombre = "Juan Pérez", Nota = 75 };
            var mockService = new Mock<IStudentService>();
            mockService.Setup(x => x.GetStudent(123)).Returns(student);
            var controller = new StudentController(mockService.Object);

            var result = controller.GetStudent(123);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
            var returnedStudent = Assert.IsType<Estudiante>(okResult.Value!);
            Assert.Equal(student.CI, returnedStudent.CI);
            Assert.Equal(student.Nombre, returnedStudent.Nombre);
            Assert.Equal(student.Nota, returnedStudent.Nota);
        }

        [Fact]
        public void GetStudent_WithDifferentCI_ReturnsCorrectStudent()
        {
            var student = new Estudiante { CI = 456, Nombre = "María Rodríguez", Nota = 85 };
            var mockService = new Mock<IStudentService>();
            mockService.Setup(x => x.GetStudent(456)).Returns(student);
            var controller = new StudentController(mockService.Object);

            var result = controller.GetStudent(456);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
            var returnedStudent = Assert.IsType<Estudiante>(okResult.Value!);
            Assert.Equal(student.CI, returnedStudent.CI);
            Assert.Equal(student.Nombre, returnedStudent.Nombre);
            Assert.Equal(student.Nota, returnedStudent.Nota);
        }

        [Fact]
        public void CheckApproval_WithLowGrade_ReturnsFalse()
        {
            var student = new Estudiante { CI = 789, Nombre = "Carlos González", Nota = 59 };
            var mockService = new Mock<IStudentService>();
            mockService.Setup(x => x.HasApproved(789)).Returns(false);
            var controller = new StudentController(mockService.Object);

            var result = controller.CheckApproval(789);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
            Assert.False((bool)okResult.Value!);
        }
    }

    /// <summary>
    /// Implementación de un Stub manual para el servicio de estudiantes.
    /// Un Stub es una implementación simple que devuelve valores predefinidos.
    /// </summary>
    public class StubStudentService : IStudentService
    {
        private readonly bool _hasApproved;
        private readonly Estudiante _student;

        public StubStudentService(bool hasApproved, Estudiante student)
        {
            _hasApproved = hasApproved;
            _student = student;
        }

        public bool HasApproved(int ci)
        {
            return _hasApproved;
        }

        public Estudiante GetStudent(int ci)
        {
            return _student;
        }
    }

    /// <summary>
    /// Pruebas del controlador usando un Stub manual en lugar de Moq.
    /// Esto demuestra una alternativa al uso de mocks.
    /// </summary>
    public class StudentControllerStubTests
    {
        [Fact]
        public void CheckApproval_WithStub_ReturnsCorrectResult()
        {
            var student = new Estudiante { CI = 123, Nombre = "Juan Pérez", Nota = 75 };
            var stubService = new StubStudentService(true, student);
            var controller = new StudentController(stubService);

            var result = controller.CheckApproval(123);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
            Assert.True((bool)okResult.Value!);
        }

        [Fact]
        public void GetStudent_WithStub_ReturnsCorrectStudent()
        {
            var student = new Estudiante { CI = 123, Nombre = "Juan Pérez", Nota = 75 };
            var stubService = new StubStudentService(true, student);
            var controller = new StudentController(stubService);

            var result = controller.GetStudent(123);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
            var returnedStudent = Assert.IsType<Estudiante>(okResult.Value!);
            Assert.Equal(student.CI, returnedStudent.CI);
            Assert.Equal(student.Nombre, returnedStudent.Nombre);
            Assert.Equal(student.Nota, returnedStudent.Nota);
        }

        [Fact]
        public void GetStudent_WithDifferentCIAndStub_ReturnsCorrectStudent()
        {
            var student = new Estudiante { CI = 456, Nombre = "María Rodríguez", Nota = 85 };
            var stubService = new StubStudentService(true, student);
            var controller = new StudentController(stubService);

            var result = controller.GetStudent(456);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
            var returnedStudent = Assert.IsType<Estudiante>(okResult.Value!);
            Assert.Equal(student.CI, returnedStudent.CI);
            Assert.Equal(student.Nombre, returnedStudent.Nombre);
            Assert.Equal(student.Nota, returnedStudent.Nota);
        }

        [Fact]
        public void CheckApproval_WithLowGradeAndStub_ReturnsFalse()
        {
            var student = new Estudiante { CI = 789, Nombre = "Carlos González", Nota = 59 };
            var stubService = new StubStudentService(false, student);
            var controller = new StudentController(stubService);

            var result = controller.CheckApproval(789);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
            Assert.False((bool)okResult.Value!);
        }
    }
} 