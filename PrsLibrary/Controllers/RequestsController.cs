using Microsoft.EntityFrameworkCore;

using PrsLibrary.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsLibrary.Controllers {
    
    public class RequestsController {

        private readonly PrsDbContext _context;

        public RequestsController(PrsDbContext context) {
            this._context = context;
        }

        public IEnumerable<Request> GetAll() {
            return _context.Requests.Include(x => x.User).ToList();
        }

        public Request GetByPk(int id) {
            return _context.Requests.Include(x => x.User)
                                .SingleOrDefault(x => x.Id == id);
        }

        public Request Create(Request Request) {
            if (Request is null) {
                throw new ArgumentNullException("Request");
            }
            if (Request.Id != 0) {
                throw new ArgumentException("Request.Id must be zero!");
            }
            _context.Requests.Add(Request);
            _context.SaveChanges();
            return Request;
        }

        public void Change(Request user) {
            _context.SaveChanges();
        }

        public void Remove(int id) {
            var Request = _context.Requests.Find(id);
            if (Request is null) {
                throw new Exception("Request not found!");
            }
            _context.Requests.Remove(Request);
            _context.SaveChanges();
        }
    }
}
