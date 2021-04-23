using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.Repository;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SupplierController : ControllerBase
    {
        private ISupplierRepository _supplierRepository;
        

        public SupplierController(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
           
        }

        [HttpGet("")]
        public IActionResult GetAllSuppliers()
        {
            var suppliers = _supplierRepository.GetAllSuppliers();
            return Ok(suppliers);
        }

        [HttpGet("{id}")]
        public ActionResult GetSupplierById([FromRoute]int id)
        {
            var supplier = _supplierRepository.GetSupplierById(id);
            if(supplier==null)
            {
                return NotFound();
            }
            return Ok(supplier);
        }
        [HttpPost("")]
        public ActionResult AddSupplier([FromBody] Supplier supplier)
        {
            int id= _supplierRepository.AddSupplier(supplier);
            return Ok(id);
          
        }
    }
}
