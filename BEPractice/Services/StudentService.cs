using BEPractice.Models;
using System.Collections.Generic;

namespace BEPractice.Services
{
    public class StudentService : IStudentService
    {
        private readonly Dictionary<int, Estudiante> _students;

        public StudentService()
        {
            _students = new Dictionary<int, Estudiante>
            {
                { 123, new Estudiante { CI = 123, Nombre = "Juan Pérez", Nota = 75 } },
                { 456, new Estudiante { CI = 456, Nombre = "María Rodríguez", Nota = 85 } },
                { 789, new Estudiante { CI = 789, Nombre = "Carlos González", Nota = 59 } }
            };
        }

        public bool HasApproved(int ci)
        {
            if (!_students.ContainsKey(ci))
                return false;

            return _students[ci].Nota >= 51;
        }

        public Estudiante GetStudent(int ci)
        {
            return _students.ContainsKey(ci) ? _students[ci] : new Estudiante { CI = -1, Nombre = string.Empty, Nota = 0 };
        }

        public void AddStudent(Estudiante student)
        {
            _students[student.CI] = student;
        }
    }
}