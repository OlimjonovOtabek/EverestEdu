using EverestEduApplication.Abstractions;
using EverestEduApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace EverstEdu.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Policy = "AdminActions")]
    public class TeacherContoller : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherContoller(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTeacherModel model)
        {
            await _teacherService.CreateAsync(model);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateTeacherModel model)
        {
            await _teacherService.UpdateAsync(model);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var teacher = await _teacherService.GetByIdAsync(id);

            return Ok(teacher);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teacherList = await _teacherService.GetAllAsync();

            return Ok(teacherList);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _teacherService.DeleteAsync(id);

            return Ok();
        }
    }
}
