using Inventory;
using UnityEngine;
using UnityEngine.UIElements;
using Utilities;

namespace UI
{
    public class InventorySlot : VisualElement
    {
        public ItemScriptableObject Item; // use for tooltip parameter
        public Image Icon;
        public Label AmountLabel;

        public InventorySlot()
        {
            Icon = this.CreateChild<Image>("InventorySlotImage");
            AmountLabel = this.CreateChild<Label>("InventorySlotAmount");
        }

        public void Set(ItemScriptableObject item)
        {
            Debug.Log($"InventorySlot Set with: {item.name}");
            Item = item;
            Icon.image = item.icon.texture;
            AmountLabel.text = item.quantity > 1 ? item.quantity.ToString() : string.Empty;
            AmountLabel.visible = item.quantity > 1;
        }

        public void Remove()
        {
            Item = null;
            Icon.sprite = null;
        }
    }
}