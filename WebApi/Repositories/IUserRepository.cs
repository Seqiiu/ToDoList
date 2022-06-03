using System.Collections.Generic;
using System.Linq;
using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IUserRepository
    {
        public User2Model ShowUserById(int id);
        public List<User2Model> GetAll();
        public void Add(User2Model user);
        public void Update(int userid, User2Model user);
        public void Delete(int userid);

    }
}
