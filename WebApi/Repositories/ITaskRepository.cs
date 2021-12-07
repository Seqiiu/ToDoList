using System.Linq;
using WebApi.Models;

namespace WebApi.Repositories
{
    public interface ITaskRepository
    {
        TaskModel Get(int taskId);
        IQueryable<TaskModel> GetAllActive();
        void Add(TaskModel task);
        void Update(int taskid, TaskModel task);
        void Delete(int taskid);

    }
}
