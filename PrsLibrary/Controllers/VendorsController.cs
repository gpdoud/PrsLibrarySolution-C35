using PrsLibrary.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsLibrary.Controllers {
    
    public class VendorsController {

        private readonly PrsDbContext _context;

        public VendorsController(PrsDbContext context) {
            _context = context;
        }

        public IEnumerable<Vendor> GetAll() {
            return _context.Vendors.ToList();
        }

        public Vendor GetByPk(int id) {
            return _context.Vendors.Find(id);
        }

        public Vendor Create(Vendor vendor) {
            _context.Vendors.Add(vendor);
            _context.SaveChanges();

            return vendor;
        }

        public void Change(Vendor vendor) {
            _context.SaveChanges();
        }

        public void Remove(int id) {
            var vendor = _context.Vendors.Find(id);
            if(vendor is not null) {
                _context.Vendors.Remove(vendor);
                _context.SaveChanges();
            }
        }
    }
}
