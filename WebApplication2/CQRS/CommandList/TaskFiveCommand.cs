using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;
using WebApplication2.CQRS.DTO;
using WebApplication2.DB;


namespace WebApplication2.CQRS.CommandList
{
    public class TaskFiveCommand : IRequest<IEnumerable<GroupAllDTO>>
    {

        public class TaskFiveCommandHandler : IRequestHandler<TaskFiveCommand, IEnumerable<GroupAllDTO>>
        {


            private readonly Db131025Context db;
            public TaskFiveCommandHandler(Db131025Context db)
            {
                this.db = db;
            }

            public async Task<IEnumerable<GroupAllDTO>> HandleAsync(TaskFiveCommand request, CancellationToken ct = default)
            {
                return await db.Groups
                    .Select(g => new GroupAllDTO
                    {
                        Id = g.Id,
                        Title = g.Title,
                        StudentCount = g.Students.Count,
                        IdSpecial = g.IdSpecial,
                        TitleSpecial = g.IdSpecialNavigation.Title
                    }).ToArrayAsync();
            }
        }
    }
}
