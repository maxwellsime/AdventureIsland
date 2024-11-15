using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class Inventory : IItemContainer
    {
        private readonly List<ItemScriptableObject> _items = new();
        
        public void AddItem(ItemScriptableObject item, int quantity = 1)
        {
            var itemIndex = _items.FindIndex(i => i.name == item.name);

            if (itemIndex == -1)
            {
                _items.Add(item);
                Debug.Log($"Item {item.name} added to Inventory.");
            }
            else
            {
                var updatedItem = _items[itemIndex];
                updatedItem.quantity += quantity;
                _items[itemIndex] = updatedItem;
                Debug.Log($"Item {item.name} added to Inventory with quantity {updatedItem.quantity}.");
            }
        }

        /* Returns true if item is removed by that quantity
         * Returns false if item cannot be removed by that quantity */
        public bool RemoveItem(ItemScriptableObject item, int quantity = 1)
        {
            if (!HasItem(item)) return false;
            var itemToRemove = _items.Find(i => i.id == item.id);
                
            if (itemToRemove.quantity > quantity)
            {
                itemToRemove.quantity -= quantity;
            } 
            else if (itemToRemove.quantity == quantity)
            {
                _items.Remove(itemToRemove);
            }
            
            return false;
        }
        
        public void Swap(int indexOne, int indexTwo)
        {
            // Don't need this until UI implementation
        }

        public bool HasItem(ItemScriptableObject item) => _items.Exists(i => i.id == item.id);
    }
}
