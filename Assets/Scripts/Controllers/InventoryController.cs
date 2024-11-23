using System;
using System.Collections;
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
            _view.InitializeView();
        }

        private void OnUpdate()
        {
            RefreshView();
        } 

        private void RefreshView()
        {
            var count = 0;
            foreach (var item in _inventory.items) {
                if(item == null) Debug.Log("ITEM NULL");
                var slot = _view.slots[0];
                if(slot == null) Debug.Log("SLOT NULL");
                _view.slots[count].Set(item);
                count++;
            }
        }
    }
}
