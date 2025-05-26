using BEPractice.Models;

namespace BEPractice.Services
{
    public interface IStudentService
    {
        bool HasApproved(int ci);
        Estudiante GetStudent(int ci);
    }
}