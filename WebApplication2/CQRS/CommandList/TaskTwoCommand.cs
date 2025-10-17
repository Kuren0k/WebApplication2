using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;
using WebApplication2.CQRS.DTO;
using WebApplication2.DB;

namespace WebApplication2.CQRS.CommandList
{
    public class TaskTwoCommand : IRequest<GenderDTO>
    {
        public required int? GroupIndex { get; set; }

        public class TaskTwoCommandHandler : IRequestHandler<TaskTwoCommand, GenderDTO>
        {


            private readonly Db131025Context db;
            public TaskTwoCommandHandler(Db131025Context db)
            {
                this.db = db;
            }

            public async Task<GenderDTO> HandleAsync(TaskTwoCommand request, CancellationToken ct = default)
            {
                var list = await db.Students
                    .Where(s => s.IdGroup == request.GroupIndex).ToListAsync();
                GenderDTO gender = new GenderDTO();
                foreach (var student in list)
                {
                    if (student.Gender == 0)
                    {
                        gender.GirlsCount++;
                    }
                    else
                    {
                        gender.BoysCount++;
                    }
                }
                return gender;
            }
        }
    }
}
