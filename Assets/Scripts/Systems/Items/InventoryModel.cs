using System;
using System.Collections.Generic;
using System.Linq;
using Inventory;
using UnityEngine;

namespace Systems.Inventory
{
    public class InventoryModel : IItemContainer
    {
        public readonly ItemScriptableObject[] Items;

        public event Action InventoryChange = delegate { };

        public InventoryModel(List<ItemScriptableObject> startingItems, int size = 30)
        {
            Items = new ItemScriptableObject[size];
            foreach (var item in startingItems)
            {
                AddItem(item);
            }
        }
        
        public bool AddItem(ItemScriptableObject item, int quantity = 1)
        {
            for (var i = 0; i < Items.Length; i++)
            {
                if (Items[i] != null)
                {
                    if (Items[i].id == item.id)
                    {
                        Items[i].quantity += quantity;
                        Debug.Log($"Item {item.name} added to Inventory with quantity {Items[i].quantity}.");
                        return SuccessfulChangeInvoke();
                    }
                    continue;
                }

                Items[i] = item;
                Debug.Log($"Item {item.name} added to Inventory.");
                return SuccessfulChangeInvoke();
            }

            return false;
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
