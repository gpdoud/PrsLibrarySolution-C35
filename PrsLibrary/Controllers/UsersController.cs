using PrsLibrary.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsLibrary.Controllers {
    
    public class UsersController {

        private readonly PrsDbContext _context;

        public UsersController(PrsDbContext context) {
            this._context = context;
        }

        public User Login(string username, string password) {
            return _context.Users
                        .SingleOrDefault(x => x.Username == username
                                            && x.Password == password);
        }

        public IEnumerable<User> GetAll() {
            return _context.Users.ToList();
        }

        public User GetByPk(int id) {
            return _context.Users.Find(id);
        }

        public User Create(User user) {
            if(user is null) {
                throw new ArgumentNullException("user");
            }
            if(user.Id != 0) {
                throw new ArgumentException("User.Id must be zero!");
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void Change(User user) {
            _context.SaveChanges();
        }

        public void Remove(int id) {
            var user = _context.Users.Find(id);
            if(user is null) {
                throw new Exception("User not found!");
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
