using System;
using System.Collections;
using System.Linq;
using Inventory;
using UI;
using UnityEngine;

namespace Controllers
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private InventoryView _view;
        [SerializeField] public Systems.Inventory.Inventory _inventory;
        
        // MULTIPLE ITEMS ADDED BECAUSE EACH ITEM IS STORED IN A PREFAB THAT HAS PERSISTENT DATA BETWEEN EACH PLAY
        
        private void OnEnable()
        {
            _inventory.InventoryChange += RefreshView();
            _view.InitializeView();
            _view.OnDrop += OnDropEvent;
            RefreshView();
        }

        private Action RefreshView()
        {
            for (var i = 0; i < _inventory.items.Count; i++)
            {
                _view.Slots[i].Set(i, _inventory.items[i]);
            }

            return () => { };
        }

        private void OnDropEvent(InventorySlot originalSlot, InventorySlot closestSlot)
        {
            _inventory.Swap(originalSlot.Index, closestSlot.Index);
            RefreshView();
        }
    }
}
