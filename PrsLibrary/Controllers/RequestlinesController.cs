using Microsoft.EntityFrameworkCore;

using PrsLibrary.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsLibrary.Controllers {
    
    public  class RequestlinesController {
        private readonly PrsDbContext _context;

        public RequestlinesController(PrsDbContext context) {
            this._context = context;
        }

        private void RecalculateRequestTotal(int requestId) {
            var request = _context.Requests.Find(requestId);

            request.Total = (from rl in _context.Requestlines
                             join p in _context.Products
                             on rl.ProductId equals p.Id
                             where rl.RequestId == requestId
                             select new {
                                 LineTotal = rl.Quantity * p.Price
                             }).Sum(x => x.LineTotal);
            _context.SaveChanges();
        }

        public IEnumerable<Requestline> GetAll() {
            return _context.Requestlines
                                .Include(x => x.Product)
                                .Include(x => x.Request)
                                .ToList();
        }

        public Requestline GetByPk(int id) {
            return _context.Requestlines
                                .Include(x => x.Product)
                                .Include(x => x.Request)
                                .SingleOrDefault(x => x.Id == id);
        }

        public Requestline Create(Requestline requestline) {
            if (requestline is null) {
                throw new ArgumentNullException("Requestline");
            }
            if (requestline.Id != 0) {
                throw new ArgumentException("Requestline.Id must be zero!");
            }
            _context.Requestlines.Add(requestline);
            _context.SaveChanges();
            RecalculateRequestTotal(requestline.RequestId);
            return requestline;
        }

        public void Change(Requestline requestline) {
            _context.SaveChanges();
            RecalculateRequestTotal(requestline.RequestId);
        }

        public void Remove(int id) {
            var requestline = _context.Requestlines.Find(id);
            if (requestline is null) {
                throw new Exception("Requestline not found!");
            }
            _context.Requestlines.Remove(requestline);
            _context.SaveChanges();
            RecalculateRequestTotal(requestline.RequestId);
        }
    }
}
