using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
   public interface IItemRepository
    {
        IEnumerable<Item> GetAllItems();
        bool AddItem(Item obj);

        Item GetItemByCode(string ItCode);
    }
}
