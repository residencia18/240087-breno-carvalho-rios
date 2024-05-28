using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade09
{
    public class ItemCollection
    {
        private readonly List<Item> _items;

        public ItemCollection()
        {
            _items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            if (item == null)
            {
                throw new ArgumentException("Item cannot be null");
            }
            _items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            if (!_items.Contains(item))
            {
                throw new ArgumentException("Item not found in the collection");
            }
            _items.Remove(item);
        }

        public List<Item> GetItems()
        {
            return _items;
        }
    }
}
