using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMediator.Types;
using WebApplication2.CQRS.CommandList;
using WebApplication2.CQRS.DTO;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly Mediator mediator;
        public StudentsController(MyMediator.Types.Mediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("ListStudentsByGroup")]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> TaskOneCommand(int groupIndex)
        {
            try
            {
                var command = new TaskOneCommand { GroupIndex = groupIndex };
                var result = await mediator.SendAsync(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ошибка: {ex.Message}");
            }

        }
    }
}
