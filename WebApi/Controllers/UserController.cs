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
    }
}
