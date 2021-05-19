using System.Collections.Generic;

namespace SuperCoolStore.Entities
{
    public sealed class Cart
    {
        private readonly IList<Item> _items = new List<Item>();

        public void AddToCart(Item item) => _items.Add(item);

        public IEnumerable<Item> GetItems() => _items;
    }
}