using Microsoft.AspNetCore.Mvc;
using university_management_service.srcs.Application.Dto.Request;
using university_management_service.srcs.Core.Interfaces.Services;

namespace university_management_service.srcs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentCreateDto studentCreate)
        {
            try
            {
                var student = await _studentService.CreateAsync(studentCreate);
                return CreatedAtAction(nameof(GetStudentByNIC), new { nic = student.NIC }, student);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{nic}")]
        public async Task<IActionResult> GetStudentByNIC(string nic)
        {
            var student = await _studentService.GetByNICAsync(nic);
            if (student == null)
            {
                return NotFound(new { message = $"Student with NIC {nic} not found." });
            }
            return Ok(student);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }
        
        [HttpPut("{nic}")]
        public async Task<IActionResult> UpdateStudent(string nic, [FromBody] StudentUpdateDto studentUpdate)
        {
            try
            {
                var student = await _studentService.UpdateAsync(nic, studentUpdate);
                return Ok(student);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
        
        [HttpDelete("{nic}")]
        public async Task<IActionResult> DeleteStudent(string nic)
        {
            var result = await _studentService.DeleteAsync(nic);
            if (!result)
            {
                return NotFound(new { message = $"Student with NIC {nic} not found." });
            }
            return NoContent();
        }
    }
}
