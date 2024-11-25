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
            _view.InitializeView();
        }

        private void Update()
        {
            RefreshView();
        } 

        private void RefreshView()
        {
            for (var i = 0; i < _inventory.items.Count; i++)
            {
                _view.slots[i].Set(_inventory.items.First());
            }
        }
    }
}
