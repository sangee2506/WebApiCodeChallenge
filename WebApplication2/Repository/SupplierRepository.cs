using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class SupplierRepository:ISupplierRepository
    {
        private WebAPIContext db;

        public SupplierRepository(WebAPIContext db)
        {
            this.db = db;
        }

        public int AddSupplier(Supplier obj)
        {
            
                db.Suppliers.Add(obj);
                db.SaveChanges();
               return obj.SuplNo;
            
           
        }

        public List<Supplier> GetAllSuppliers()
        {
            return db.Suppliers.Include(x=>x.Items).ToList();
        }

        public Supplier GetSupplierById(int id)
        {
            return db.Suppliers.Find(id);

        }
    }
}
