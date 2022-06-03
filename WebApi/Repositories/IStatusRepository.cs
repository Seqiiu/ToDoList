using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IStatusRepository
    {
        public List<StatusModel> GetAllStatus();
        public string GetStatusById(int id);
    }
}
