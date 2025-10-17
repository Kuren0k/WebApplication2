using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;
using WebApplication2.CQRS.DTO;
using WebApplication2.DB;

namespace WebApplication2.CQRS.CommandList
{
    public class TaskOneCommand : IRequest<IEnumerable<StudentDTO>>
    {
        public required int? GroupIndex { get; set; }

        public class TaskOneCommandHandler : IRequestHandler<TaskOneCommand, IEnumerable<StudentDTO>>
        {


            private readonly Db131025Context db;
            public TaskOneCommandHandler(Db131025Context db)
            {
                this.db = db;
            }

            public async Task<IEnumerable<StudentDTO>> HandleAsync(TaskOneCommand request, CancellationToken ct = default)
            {
                return await db.Students
                    .Where(s => s.IdGroup == request.GroupIndex)
                    .Select(s => new StudentDTO
                    {
                        Id = s.Id,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        Phone = s.Phone,
                        Gender = s.Gender,
                        IdGroup = s.IdGroup
                    }).ToArrayAsync();
            }
        }
    }
}
