using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/")]
    public class TackSaSController : ControllerBase
    {
        private readonly ITaskRepository _repository;
        public TackSaSController(ITaskRepository repository)
        {
           _repository = repository;
        }
        [HttpGet]
        [Route("GetListOfActiveTask")]
        public IQueryable<TaskModel> GetListOfActiveTask()
        {
            return _repository.GetAllActive();
        }
        [HttpGet]
        [Route("GetListOfTask")]
        public IQueryable<TaskModel> GetListOfTask()
        {
            return _repository.GetAll();
        }
    }
}
