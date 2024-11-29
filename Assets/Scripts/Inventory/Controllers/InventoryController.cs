using System.Collections.Generic;
using Inventory.Models;
using Inventory.Views;
using UnityEngine;

namespace Inventory.Controllers
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private InventoryView view;
        [SerializeField] public List<ItemScriptableObject> startingItems = new();
        public InventoryModel InventoryModel;
        
        // MULTIPLE ITEMS ADDED BECAUSE EACH ITEM IS STORED IN A PREFAB THAT HAS PERSISTENT DATA BETWEEN EACH PLAY

        private void OnEnable()
        {
            InventoryModel = new InventoryModel(startingItems);
            view.InitializeView();
            view.OnDrop += OnDropEvent;
            InventoryModel.InventoryChange += OnInventoryChange;
            RefreshView();
        }
        
        private void OnInventoryChange() => RefreshView();

        private void OnDropEvent(InventorySlot originalSlot, InventorySlot closestSlot)
        {
            InventoryModel.Swap(originalSlot.Index, closestSlot.Index);
        }
        
        private void RefreshView()
        {
            Debug.Log("RefreshView");
            for (var i = 0; i < InventoryModel.Items.Length; i++)
            {
                if (InventoryModel.Items[i] == null) continue;
                view.Slots[i].Set(i, InventoryModel.Items[i].icon.texture, InventoryModel.Items[i].quantity);
            }
        }
    }
}
