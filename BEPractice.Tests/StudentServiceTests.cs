using Xunit;
using BEPractice.Models;
using BEPractice.Services;

namespace BEPractice.Tests
{
    /// <summary>
    /// Pruebas unitarias para el servicio StudentService.
    /// Estas pruebas verifican la lógica de negocio relacionada con la aprobación de estudiantes.
    /// </summary>
    public class StudentServiceTests
    {
        [Fact]
        public void HasApproved_WithPassingGrade_ReturnsTrue()
        {
            var service = new StudentService();
            var student = new Estudiante { CI = 123, Nombre = "Juan Pérez", Nota = 75 };
            service.AddStudent(student);

            var result = service.HasApproved(123);

            Assert.True(result);
        }

        [Fact]
        public void HasApproved_WithFailingGrade_ReturnsFalse()
        {
            var service = new StudentService();
            var student = new Estudiante { CI = 456, Nombre = "María Rodríguez", Nota = 49 };
            service.AddStudent(student);

            var result = service.HasApproved(456);

            Assert.False(result);
        }

        [Fact]
        public void HasApproved_WithMinimumPassingGrade_ReturnsTrue()
        {
            var service = new StudentService();
            var student = new Estudiante { CI = 789, Nombre = "Carlos González", Nota = 51 };
            service.AddStudent(student);

            var result = service.HasApproved(789);

            Assert.True(result);
        }

        [Fact]
        public void HasApproved_WithNonExistentStudent_ReturnsFalse()
        {
            var service = new StudentService();

            var result = service.HasApproved(999);

            Assert.False(result);
        }

        [Fact]
        public void GetStudent_ReturnsCorrectStudent()
        {
            // Arrange: Configuramos un estudiante con datos específicos
            var student = new Estudiante { CI = 123, Nombre = "John Doe", Nota = 75 };
            var service = new StudentService();
            service.AddStudent(student);

            // Act: Obtenemos el estudiante por su CI
            var result = service.GetStudent(student.CI);

            // Assert: Verificamos que todos los datos coincidan
            Assert.NotNull(result);
            Assert.Equal(student.CI, result.CI);
            Assert.Equal(student.Nombre, result.Nombre);
            Assert.Equal(student.Nota, result.Nota);
        }

        [Fact]
        public void GetStudent_WithNonExistentCI_ReturnsEmptyEstudiante()
        {
            // Arrange: Creamos un servicio sin estudiantes
            var service = new StudentService();

            // Act: Intentamos obtener un estudiante con un CI que no existe
            var result = service.GetStudent(999);

            // Assert: Verificamos que el resultado sea un Estudiante vacío
            Assert.NotNull(result);
            Assert.Equal(-1, result.CI);
            Assert.Equal(string.Empty, result.Nombre);
            Assert.Equal(0, result.Nota);
        }
    }
} 