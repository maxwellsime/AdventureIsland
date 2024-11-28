using System;
using System.Collections.Generic;
using System.Linq;
using Inventory;
using UnityEngine;

namespace Systems.Inventory
{
    public class Inventory : MonoBehaviour, IItemContainer
    {
        public ItemScriptableObject[] items = new ItemScriptableObject[30];

        public event Action InventoryChange = delegate { };
        
        public void AddItem(ItemScriptableObject item, int quantity = 1)
        {
            InventoryChange?.Invoke();

            for (var i = 0; i < items.Length; i++)
            {
                if (items[i].id == item.id)
                {
                    items[i].quantity += quantity;
                    Debug.Log($"Item {item.name} added to Inventory with quantity {items[i].quantity}.");
                    break;
                }
                if (items[i] != null) continue;
                items[i] = item;
                Debug.Log($"Item {item.name} added to Inventory.");
                break;
            }
        }

        /* Returns true if item is removed by that quantity
         * Returns false if item cannot be removed by that quantity */
        public bool RemoveItem(ItemScriptableObject item, int quantity = 1)
        {
            for (var i = 0; i < items.Length; i++)
            {
                if (!EqualityComparer<ItemScriptableObject>.Default.Equals(item, items[i])) continue;
                if (items[i].quantity > quantity)
                {
                    items[i].quantity -= quantity;
                    return true;

                }

                if (items[i].quantity != quantity) continue;
                items[i] = null;
                return true;
            }

            return false;
        }
        
        public void Swap(int indexOne, int indexTwo) =>
            (items[indexOne], items[indexTwo]) = (items[indexTwo], items[indexOne]);

        public bool HasItem(ItemScriptableObject item) => 
            items.FirstOrDefault(i => i.id == item.id) != null;
    }
}
