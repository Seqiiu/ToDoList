using System.Collections.Generic;
using System.Linq;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly TaskMenagerContext _context;
        public StatusRepository(TaskMenagerContext context)
        {

            _context = context;
        }
        public List<StatusModel> GetAllStatus() => _context.Statuses.ToList();
        public string GetStatusById(int id) => _context.Statuses.FirstOrDefault(x => x.StatusId == id).Name;

    }
}
