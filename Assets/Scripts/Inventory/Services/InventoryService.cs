using System;
using System.Collections.Generic;
using System.Linq;
using Inventory.Models;
using UnityEngine;

namespace Inventory.Services
{
    public class InventoryService : IItemContainerService
    {
        public ItemScriptableObject[] Items;

        public event Action InventoryChange = delegate { };

        public InventoryService(List<ItemScriptableObject> startingItems, int size = 30)
        {
            Items = new ItemScriptableObject[size];
            foreach (var item in startingItems)
            {
                AddItem(item);
            }

            ItemGameObject.OnClick += AddItem;
        }
        
        public void AddItem(ItemScriptableObject item, int quantity = 1)
        {
            var firstEmptyIndex = -1;
            
            // Checking if item exists already.
            for (var i = 0; i < Items.Length; i++)
            {
                if (Items[i] != null)
                {
                    if (Items[i].id != item.id) continue;
                    
                    Items[i].quantity += quantity;
                    Debug.Log($"{item.quantity} {item.name} added to Inventory with quantity {quantity}.");
                    InventoryChange?.Invoke();
                    return;
                } 
                if(firstEmptyIndex == -1)
                {
                    firstEmptyIndex = i;
                }
            }
            
            // Array is full.
            if (firstEmptyIndex == -1)
            {
                Array.Resize(ref Items, Items.Length + 5);
                firstEmptyIndex = Items.Length + 1;
            }
            
            // Item doesn't already exist.
            item.quantity = quantity;
            Items[firstEmptyIndex] = item;
            Debug.Log($"{quantity} {item.name} added to Inventory.");
            InventoryChange?.Invoke();
        }

        public bool RemoveItem(ItemScriptableObject item, int quantity = 1)
        {
            for (var i = 0; i < Items.Length; i++)
            {
                if (!EqualityComparer<ItemScriptableObject>.Default.Equals(item, Items[i])) continue;
                if (Items[i].quantity > quantity)
                {
                    Items[i].quantity -= quantity;
                    return SuccessfulChangeInvoke();
                }

                if (Items[i].quantity != quantity) continue;
                Items[i] = null;
                return SuccessfulChangeInvoke();
            }

            return false;
        }

        public void Swap(int indexOne, int indexTwo)
        {
            (Items[indexOne], Items[indexTwo]) = (Items[indexTwo], Items[indexOne]);
            InventoryChange?.Invoke();
        }
        
        public bool HasItem(ItemScriptableObject item) => 
            Items.FirstOrDefault(i => i.id == item.id) != null;
        
        private bool SuccessfulChangeInvoke()
        {
            InventoryChange?.Invoke();
            return true;
        }
    }
}
