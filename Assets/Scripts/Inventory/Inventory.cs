using System.Collections.Generic;
using Inventory.Controllers;
using Inventory.Models;
using Inventory.Services;
using Inventory.Views;
using UnityEngine;
using UnityEngine.UIElements;

namespace Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private List<ItemScriptableObject> startingItems;
        [SerializeField] private UIDocument uiDocument;

        public void Awake()
        {
            var inventoryView = new InventoryView(uiDocument);
            var inventoryService = new InventoryService(startingItems);     // save data inventory data
            var inventoryController = new InventoryController(inventoryView, inventoryService);
            StartCoroutine(inventoryController.Initialize());
            
            DontDestroyOnLoad(this);
        }
    }
}