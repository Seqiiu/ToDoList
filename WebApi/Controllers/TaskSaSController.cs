using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/")]
    public class TaskSaSController : ControllerBase
    {
        private readonly ITaskRepository _repository;
        private readonly TaskMenagerContext _context;
        private readonly IWebHostEnvironment _webHost;

        public TaskSaSController(ITaskRepository repository, TaskMenagerContext context, IWebHostEnvironment webHost)
        {

           _repository = repository;
            _context = context;
            _webHost = webHost;
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
        [Route("Wykres")]
        public ContentResult Wykres()
        {

            string appPath = @"C:\Program Files\SASHome\SASFoundation\9.4\sas.exe";
            string appArgs = @"C:\Users\Seqiiu\Source\Repos\Seqiiu\ToDoList\WebApi\wwwroot\SAS\wykres.sas";
            Process proc = new Process();
            ProcessStartInfo si = new ProcessStartInfo(appPath, appArgs);
            si.WindowStyle = ProcessWindowStyle.Normal;
            si.Verb = "runas";            
            si.UseShellExecute = true;     
            proc.StartInfo = si;
            proc.Start();
            proc.WaitForExit();

            return new ContentResult
            {
                ContentType = "text/html",
                Content = "<div><img src=\"https://localhost:44300//SAS//wykres.png\" /></div>"
            };
        }
    }
}
