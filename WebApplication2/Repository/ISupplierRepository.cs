using System;
using System.Collections.Generic;

using WebApplication2.Models;

namespace WebApplication2.Repository
{
   public  interface ISupplierRepository
    {
       List<Supplier> GetAllSuppliers();
       int AddSupplier(Supplier obj);

       Supplier GetSupplierById(int id);

    }
}
