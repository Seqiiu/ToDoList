using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskMenagerContext _context;
        public UserRepository(TaskMenagerContext context)
        {
            _context = context;
        }
        public List<User2Model> GetAll() => _context.User2s.ToList();
        public User2Model ShowUserById(int id) => _context.User2s.SingleOrDefault(x => x.User2Id == id);
    
        public void Add(User2Model user)
        {
            if (user != null && user != default)
            {
                user.DateOfCreated = DateTime.Now;
                _context.Add(user);             
                _context.SaveChanges();
            }
        }
        public void Update(int userid, User2Model user)
        {
            var result = _context.User2s.SingleOrDefault(x => x.User2Id == userid);
            if (result != null)
            {
                result.Name = user.Name;
                result.Email = user.Email;
                result.LastName = user.LastName;
                _context.SaveChanges();
            }
        }
        public void Delete(int userid)
        {
            var resoult = _context.User2s.SingleOrDefault(x => x.User2Id == userid);
            if (resoult != null)
            {
                var  k = _context.Tasks.Where(x => x.User2Id == userid).ToList();
                foreach (var item in k)
                {
                    _context.Remove(item);
                }
                _context.User2s.Remove(resoult);

                _context.SaveChanges();
            }
        }
    }
}
