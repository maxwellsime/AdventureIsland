using Inventory.Controllers;
using Inventory.Models;
using UnityEngine;
using UnityEngine.UIElements;

namespace Overworld.GameObjects
{
    public class ItemInteractable : MonoBehaviour
    {
        public ItemScriptableObject itemScriptableObject;
        private InventoryController _inventoryController;
        private BoxCollider2D _collider;
        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            _inventoryController = GameObject.Find("SystemsManager").GetComponent<InventoryController>();
            _collider = GetComponent<BoxCollider2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _collider.enabled = true;
            _spriteRenderer.enabled = true;
        }

        private void OnMouseDown()
        {
            _inventoryController.InventoryModel.AddItem(itemScriptableObject);
            _collider.enabled = false;
            _spriteRenderer.enabled = false;
        }
    }
}
