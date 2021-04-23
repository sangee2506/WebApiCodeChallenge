using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class ItemRepository : IItemRepository
    {
        private WebAPIContext db;

        public ItemRepository(WebAPIContext db)
        {
            this.db = db;
        }
        public bool AddItem(Item obj)
        {
            bool status;
            try
            {
                db.Items.Add(obj);
                db.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public IEnumerable<Item> GetAllItems()
        {
            return db.Items.ToList();
        }

        public Item GetItemByCode(string ItCode)
        {
            List<Item> itemList = db.Items.ToList();
            Item item = itemList.Find(x => x.ItCode == ItCode);
            return item;


        }
    }
}
