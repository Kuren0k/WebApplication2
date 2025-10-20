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

        [HttpGet("ListStudentsMalOrDevByGroup")]
        public async Task<ActionResult<IEnumerable<GenderDTO>>> TaskTwoCommand(int groupIndex)
        {
            try
            {
                var command = new TaskTwoCommand { GroupIndex = groupIndex };
                var result = await mediator.SendAsync(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ошибка: {ex.Message}");
            }
        }

        [HttpGet("ListStudentsNotByGroup")]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> TaskThreeCommand()
        {
            try
            {
                var command = new TaskOneCommand { GroupIndex = null };
                var result = await mediator.SendAsync(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ошибка: {ex.Message}");
            }
        }

        [HttpGet("ListGroupNotByStudents")]
        public async Task<ActionResult<IEnumerable<GroupDTO>>> TaskFourCommand()
        {
            try
            {
                var command = new TaskFourCommand();
                var result = await mediator.SendAsync(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ошибка: {ex.Message}");
            }
        }

        [HttpGet("ListAllGroup")]
        public async Task<ActionResult<IEnumerable<GroupAllDTO>>> TaskFiveCommand()
        {
            try
            {
                var command = new TaskFiveCommand();
                var result = await mediator.SendAsync(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ошибка: {ex.Message}");
            }
        }

        [HttpPost("AddGroup")]
        public async Task<ActionResult> AddGender(string title, int idSpecial)
        {
            var command = new TaskSevenCommand { Title = title, IdSpecial = idSpecial };
            try
            {
                await mediator.SendAsync(command);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

        [HttpPost("UpdateStudent")]
        public async Task<ActionResult> UpdateStudent(int idStudent, int idGroup)
        {
            var command = new TaskEightCommand { IdStudent = idStudent, IdGroup = idGroup };
            try
            {
                await mediator.SendAsync(command);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
    }
}
