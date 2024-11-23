using Inventory;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    public class InventorySlot : VisualElement
    {
        public ItemScriptableObject Item = null;
        public Image Icon = new();

        public InventorySlot()
        {
            Add(Icon);
        }

        public void Set(ItemScriptableObject item)
        {
            Debug.Log($"InventorySlot Set with: {item.name ?? "null"}");
            Item = item;
            Icon.image = item.icon.texture;
            Add(Icon);
        }

        public void Remove()
        {
            Item = null;
            Icon.sprite = null;
        }
    }
}