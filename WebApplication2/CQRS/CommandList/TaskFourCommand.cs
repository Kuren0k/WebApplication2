using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;
using WebApplication2.CQRS.DTO;
using WebApplication2.DB;

namespace WebApplication2.CQRS.CommandList
{
    public class TaskFourCommand : IRequest<IEnumerable<GroupDTO>>
    {

        public class TaskFourCommandHandler : IRequestHandler<TaskFourCommand, IEnumerable<GroupDTO>>
        {


            private readonly Db131025Context db;
            public TaskFourCommandHandler(Db131025Context db)
            {
                this.db = db;
            }

            public async Task<IEnumerable<GroupDTO>> HandleAsync(TaskFourCommand request, CancellationToken ct = default)
            {
                return await db.Groups
                    .Where(g => g.Students.Count == 0)
                    .Select(g => new GroupDTO
                    {
                        Id = g.Id,
                        Title = g.Title
                    }).ToArrayAsync();
            }
        }
    }
}
