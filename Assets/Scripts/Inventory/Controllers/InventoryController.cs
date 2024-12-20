using System.Collections;
using Inventory.Services;
using Inventory.Views;
using UnityEngine;

namespace Inventory.Controllers
{
    public class InventoryController
    {
        private readonly InventoryView _inventoryView;
        private readonly InventoryService _inventoryService;

        public InventoryController(
            InventoryView inventoryView,
            InventoryService inventoryService) 
        {
            _inventoryView = inventoryView;
            _inventoryService = inventoryService;
        }

        public IEnumerator Initialize()
        {
            yield return _inventoryView.Initialize();
            
            _inventoryView.OnDrop += OnDropEvent;
            _inventoryService.InventoryChange += RefreshView;
            _inventoryService.InventoryAdd += InventoryView.ItemPopup;
            
            RefreshView();
        }
        
        private void OnDropEvent(InventorySlot originalSlot, InventorySlot closestSlot)
        {
            _inventoryService.Swap(originalSlot.Index, closestSlot.Index);
        }
        
        private void RefreshView()
        {
            Debug.Log("Refresh inventory view.");
            for (var i = 0; i < _inventoryService.Items.Length; i++)
            {
                if (_inventoryService.Items[i] is null) continue;
                _inventoryView.Slots[i].Set(
                    i, _inventoryService.Items[i].icon.texture,
                    _inventoryService.Items[i].quantity
                    );
            }
        }
    }
}
