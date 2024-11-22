using Inventory;
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
            Item = item;
            Icon.sprite = item.icon;
        }

        public void Remove()
        {
            Item = null;
            Icon.sprite = null;
        }
    }
}