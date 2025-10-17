using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;
using WebApplication2.CQRS.DTO;
using WebApplication2.DB;

namespace WebApplication2.CQRS.CommandList
{
    public class TaskSixCommand : IRequest<IEnumerable<GroupAllDTO>>
    {
        public required int? SpecialIndex { get; set; }
        public class TaskSixCommandHandler : IRequestHandler<TaskSixCommand, IEnumerable<GroupAllDTO>>
        {


            private readonly Db131025Context db;
            public TaskSixCommandHandler(Db131025Context db)
            {
                this.db = db;
            }

            public async Task<IEnumerable<GroupAllDTO>> HandleAsync(TaskSixCommand request, CancellationToken ct = default)
            {
                return await db.Groups
                    .Where(s => s.IdSpecial == request.SpecialIndex)
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
