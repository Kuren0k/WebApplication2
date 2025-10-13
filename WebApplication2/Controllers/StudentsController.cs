using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMediator.Types;
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
        public async Task<ActionResult<IEnumerable<StudentDTO>>>
    }
}
