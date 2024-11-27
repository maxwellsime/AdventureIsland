using System.Collections.Generic;
using Inventory;
using UnityEngine;
using UnityEngine.Serialization;

namespace Systems.Inventory
{
    public class Inventory : MonoBehaviour, IItemContainer
    {
        [SerializeField] public List<ItemScriptableObject> items;
        
        public void AddItem(ItemScriptableObject item, int quantity = 1)
        {
            var itemIndex = items.FindIndex(i => i.name == item.name);

            if (itemIndex == -1)
            {
                items.Add(item);
                Debug.Log($"Item {item.name} added to Inventory.");
            }
            else
            {
                var updatedItem = items[itemIndex];
                updatedItem.quantity += quantity;
                items[itemIndex] = updatedItem;
                Debug.Log($"Item {item.name} added to Inventory with quantity {updatedItem.quantity}.");
            }
        }

        /* Returns true if item is removed by that quantity
         * Returns false if item cannot be removed by that quantity */
        public bool RemoveItem(ItemScriptableObject item, int quantity = 1)
        {
            if (!HasItem(item)) return false;
            var itemToRemove = items.Find(i => i.id == item.id);
                
            if (itemToRemove.quantity > quantity)
            {
                itemToRemove.quantity -= quantity;
            } 
            else if (itemToRemove.quantity == quantity)
            {
                items.Remove(itemToRemove);
            }
            
            return false;
        }
        
        public void Swap(int indexOne, int indexTwo) =>
            (items[indexOne], items[indexTwo]) = (items[indexTwo], items[indexOne]);

        public bool HasItem(ItemScriptableObject item) => items.Exists(i => i.id == item.id);
    }
}
