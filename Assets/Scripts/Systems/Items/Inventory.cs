using System.Collections.Generic;
using Inventory;
using UnityEngine;

namespace Systems.Inventory
{
    public class Inventory : IItemContainer
    {
        public List<ItemScriptableObject> Items = new();
        
        public void AddItem(ItemScriptableObject item, int quantity = 1)
        {
            var itemIndex = Items.FindIndex(i => i.name == item.name);

            if (itemIndex == -1)
            {
                Items.Add(item);
                Debug.Log($"Item {item.name} added to Inventory.");
            }
            else
            {
                var updatedItem = Items[itemIndex];
                updatedItem.quantity += quantity;
                Items[itemIndex] = updatedItem;
                Debug.Log($"Item {item.name} added to Inventory with quantity {updatedItem.quantity}.");
            }
        }

        /* Returns true if item is removed by that quantity
         * Returns false if item cannot be removed by that quantity */
        public bool RemoveItem(ItemScriptableObject item, int quantity = 1)
        {
            if (!HasItem(item)) return false;
            var itemToRemove = Items.Find(i => i.id == item.id);
                
            if (itemToRemove.quantity > quantity)
            {
                itemToRemove.quantity -= quantity;
            } 
            else if (itemToRemove.quantity == quantity)
            {
                Items.Remove(itemToRemove);
            }
            
            return false;
        }
        
        public void Swap(int indexOne, int indexTwo)
        {
            // Don't need this until UI implementation
        }

        public bool HasItem(ItemScriptableObject item) => Items.Exists(i => i.id == item.id);
    }
}
