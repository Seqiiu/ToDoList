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
        {
            var res = _context.Tasks.SingleOrDefault(x => x.TaskId == taskId);
            res.Status = _context.Statuses.SingleOrDefault(x => x.StatusId ==res.StatusId);
            res.User2 = _context.User2s.SingleOrDefault(x => x.User2Id == res.User2Id);
            return res;
        }
           

        public IQueryable<TaskModel> GetAllActive()
        {
            var resout = _context.Tasks.Where(x => x.Done == false);
            return resout;
        }
        public void Add(TaskModel task)
        {
            _context.Tasks.Add(task);
            task.StatusId = 1;
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
                result.StatusId = task.StatusId;
                result.User2Id = task.User2Id;
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

        public IQueryable<TaskModel> GetAll()
        {
            return _context.Tasks;
        }
    }
}
