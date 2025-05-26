using Microsoft.AspNetCore.Mvc;
using BEPractice.Models;
using BEPractice.Services;

namespace BEPractice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("approval/{ci}")]
        public IActionResult CheckApproval(int ci)
        {
            var hasApproved = _studentService.HasApproved(ci);
            return Ok(hasApproved);
        }

        [HttpGet("{ci}")]
        public IActionResult GetStudent(int ci)
        {
            var student = _studentService.GetStudent(ci);
            if (student == null)
                return NotFound();
            return Ok(student);
        }
    }
}