using EverestEduApplication.Abstractions;
using EverestEduApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EverstEdu.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "AdminActions")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentModel model)
        {
            await _studentService.CreateAsync(model);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateStudentModel model)
        {
            await _studentService.UpdateAsync(model);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var teacher = await _studentService.GetByIdAsync(id);

            return Ok(teacher);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var studentList = await _studentService.GetAllAsync();

            return Ok(studentList);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _studentService.DeleteAsync(id);

            return Ok();
        }
    }
}
