using Controllers;
using UnityEngine;

namespace Inventory
{
    public class ItemInteractable : MonoBehaviour
    {
        public ItemScriptableObject itemScriptableObject;
        private InventoryController _inventoryController;

        private void Start()
        {
            _inventoryController = GameObject.Find("SystemsManager").GetComponent<InventoryController>();
        }

        private void OnMouseDown()
        {
            _inventoryController.InventoryModel.AddItem(itemScriptableObject);
        }
    }
}
