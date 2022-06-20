using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/")]
    public class TaskSaSController : ControllerBase
    {
        private readonly ITaskRepository _repository;
        public TaskSaSController(ITaskRepository repository)
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
        [HttpGet]
        [Route("OnKonsole")]
        public IActionResult OnKonsole()
        {
            string appPath = @"...";
            string appArgs = @"...";
            Process proc = new Process();
            ProcessStartInfo si = new ProcessStartInfo(appPath, appArgs);
            si.WindowStyle = ProcessWindowStyle.Normal;
            si.Verb = "runas";             // UAC elevation required.
            si.UseShellExecute = true;     // Required for UAC elevation.
            proc.StartInfo = si;
            proc.Start();
            proc.WaitForExit();
            return Ok();
        }
    }
}
