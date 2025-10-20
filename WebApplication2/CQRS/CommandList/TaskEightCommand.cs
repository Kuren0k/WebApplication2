using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;
using MyMediator.Types;
using WebApplication2.CQRS.DTO;
using WebApplication2.DB;


namespace WebApplication2.CQRS.CommandList
{
    public class TaskEightCommand : IRequest
    {
        public int IdStudent { get; set; }
        public int IdGroup { get; set; }
        public class TaskEightCommandHandler : IRequestHandler<TaskEightCommand, Unit>
        {
            private readonly Db131025Context db;

            public TaskEightCommandHandler(Db131025Context db)
            {
                this.db = db;
            }
            public async Task<Unit> HandleAsync(TaskEightCommand request, CancellationToken ct = default)
            {
                var student = db.Students.FirstOrDefault(a => a.Id == request.IdStudent);
                var group = db.Groups.FirstOrDefault(a => a.Id == request.IdGroup);
                if (student == null || group == null)
                {
                    return Unit.Value;
                }
                
                student.IdGroup = request.IdGroup;
                db.Students.Update(student);
                await db.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
