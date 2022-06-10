using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _user;
        public UserController(IUserRepository user)
        {
            _user = user;
        }
        // GET: User/Create
        public ActionResult Create()
        {
            return View(new User2Model());
        }
        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User2Model user)
        {
            _user.Add(user);
            return RedirectToAction("Index","Task");
        }
        // GET: User
        public ActionResult Index() => View(_user.GetAll());
        // GET: User/Details/5
        public ActionResult Details(int id) => View(_user.ShowUserById(id));
        // GET: User/Edit/5
        public ActionResult Edit(int id) => View(_user.ShowUserById(id));
        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User2Model userModel)
        {
            _user.Update(id, userModel);
            return RedirectToAction(nameof(Index));
        }
        // GET: User/Delete/5
        public ActionResult Delete(int id) => View(_user.ShowUserById(id));
        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TaskModel taskModel)
        {
            _user.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

