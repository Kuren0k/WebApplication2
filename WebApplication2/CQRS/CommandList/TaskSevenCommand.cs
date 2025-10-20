using MyMediator.Interfaces;
using MyMediator.Types;
using WebApplication2.CQRS.DTO;
using WebApplication2.DB;

namespace WebApplication2.CQRS.CommandList
{
    public class TaskSevenCommand : IRequest
    {

        public string? Title { get; set; }

        public int? IdSpecial { get; set; }

        public class TaskSevenCommandHandler : IRequestHandler<TaskSevenCommand, Unit>
        {
            private readonly Db131025Context db;

            public TaskSevenCommandHandler(Db131025Context db)
            {
                this.db = db;
            }
            public async Task<Unit> HandleAsync(TaskSevenCommand request, CancellationToken ct = default)
            {
                var special = db.Specials.FirstOrDefault(a => a.Id == request.IdSpecial);
                if (special == null)
                {
                    return Unit.Value;
                }
                
                Group group = new Group { Title = request.Title, IdSpecial = special.Id, IdSpecialNavigation = special};
                db.Groups.Add(group);
                await db.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
