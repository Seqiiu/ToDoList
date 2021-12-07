using System.Linq;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskMenagerContext _context;
        public TaskRepository(TaskMenagerContext context)
        {
            _context = context;
        }
        public TaskModel Get(int taskId)
            => _context.Tasks.SingleOrDefault(x => x.TaskId == taskId);

        public IQueryable<TaskModel> GetAllActive()
        => _context.Tasks.Where(x => x.Done == false);

        public void Add(TaskModel task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }
        public void Update(int taskId, TaskModel task)
        {
            var result =_context.Tasks.SingleOrDefault(x => x.TaskId == taskId);
            if (result != null)
            {
                result.Name = task.Name;
                result.Description = task.Description;
                result.Done = task.Done;
                _context.SaveChanges();
            }
        }

        public void Delete(int taskid)
        {
            var resoult = _context.Tasks.SingleOrDefault(x => x.TaskId == taskid);
            if (resoult != null)
            {
                _context.Tasks.Remove(resoult);
                _context.SaveChanges();
            }
        }

    }
}
