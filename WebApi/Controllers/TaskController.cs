using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUserRepository _userRepository;
        private readonly IStatusRepository _status;

        public TaskController(ITaskRepository taskRepository, IUserRepository userRepository,IStatusRepository status)
        {
            _taskRepository = taskRepository;
            _userRepository = userRepository;
            _status = status;
        }
        private List<TaskModel> GetDane()
        {
            var user = _userRepository.GetAll();
            var task = _taskRepository.GetAllActive().ToList();
            var status = _status.GetAllStatus();
            for (int i = 0; i < task.Count; i++)
            {
                for (int j = 0; j < user.Count; j++)
                {
                    if (task[i].User2Id == user[j].User2Id)
                    {
                        task[i].User2.Name = user[j].Name;
                    }
                }
                for (int j = 0; j < status.Count; j++)
                {
                    if (task[i].StatusId == status[j].StatusId)
                    {
                        task[i].Status.Name = status[j].Name;
                    }
                }
            }
            return task;
        }
        // GET: Task
        public ActionResult Index()
        {
            return View(GetDane());
        }

        // GET: Task/Details/5
        public ActionResult Details(int id)
        {          
            return View(_taskRepository.Get(id));
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            ViewBag.Userlist = GetUsers(null);
            return View(new TaskModel());
        }

        // POST: Task/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskModel task)
        {
            string k = ViewBag.k;
            _taskRepository.Add(task);

            return RedirectToAction(nameof(Index));

        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Userlist = GetUsers(null);
            ViewBag.StatusList = GetStatus(null);
            return View(_taskRepository.Get(id));
        }

        // POST: Task/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TaskModel taskModel)
        {
            _taskRepository.Update(id, taskModel);
            return RedirectToAction(nameof(Index));
        }

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_taskRepository.Get(id));
        }

        // POST: Task/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TaskModel taskModel)
        {
            _taskRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        //Get:Task/Done/5
        public ActionResult Done(int id)
        {
            TaskModel task = _taskRepository.Get(id);
            task.Done = true;
            task.StatusId = 3;
            _taskRepository.Update(id, task);
            return RedirectToAction(nameof(Index));
        }



        private MultiSelectList GetUsers(string[] selectedValues)
        {
            var List = _userRepository.GetAll();
            return new MultiSelectList(List, "User2Id", "Name", selectedValues);

        }

        private MultiSelectList GetStatus(string[] selectedValues)
        {
            var List = _status.GetAllStatus();
            return new MultiSelectList(List, "StatusId", "Name", selectedValues);
        }

    }
}
