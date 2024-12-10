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
        private InventoryModel _inventoryModel;
        
        private void OnEnable()
        {
            _inventoryModel = new InventoryModel(startingItems);
            view.InitializeView();
            
            view.OnDrop += OnDropEvent;
            _inventoryModel.InventoryChange += RefreshView;
            
            RefreshView();
            DontDestroyOnLoad(this);
        }
        
        private void OnDropEvent(InventorySlot originalSlot, InventorySlot closestSlot)
        {
            _inventoryModel.Swap(originalSlot.Index, closestSlot.Index);
        }
        
        private void RefreshView()
        {
            Debug.Log("RefreshView");
            for (var i = 0; i < _inventoryModel.Items.Length; i++)
            {
                if (_inventoryModel.Items[i] == null) continue;
                view.Slots[i].Set(i, _inventoryModel.Items[i].icon.texture, _inventoryModel.Items[i].quantity);
            }
        }
    }
}
