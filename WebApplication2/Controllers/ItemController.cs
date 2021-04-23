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
    public class ItemController : ControllerBase
    {
        private IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpGet("")]
        public IActionResult GetAllItems()
        {
            var Items = _itemRepository.GetAllItems();
            return Ok(Items);
        }

        [HttpGet("{id}")]
        public ActionResult GetItemById([FromRoute] string id)
        {
            var Item = _itemRepository.GetItemByCode(id);
            if (Item == null)
            {
                return NotFound();
            }
            return Ok(Item);
        }
        [HttpPost("")]
        public ActionResult AddItem([FromBody] Item Item)
        {
            bool status = _itemRepository.AddItem(Item);
            return Ok(status);

        }
    }
}
