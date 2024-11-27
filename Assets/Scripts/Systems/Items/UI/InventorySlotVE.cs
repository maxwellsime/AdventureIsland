using System;
using Inventory;
using UnityEngine;
using UnityEngine.UIElements;
using Utilities;

namespace UI
{
    public class InventorySlot : VisualElement
    {
        public int Index;
        public ItemScriptableObject Item; // use for tooltip parameter
        public Image Icon;
        public Label AmountLabel;

        public event Action<Vector2, InventorySlot> OnStartDrag = delegate { };
        
        public InventorySlot()
        {
            Icon = this.CreateChild<Image>("InventorySlotImage");
            AmountLabel = this.CreateChild<Label>("InventorySlotAmount");
            RegisterCallback<PointerDownEvent>(OnPointerDown);
        }

        private void OnPointerDown(PointerDownEvent evt)
        {
            if (evt.button != 0 || Item == null) return;
            
            OnStartDrag.Invoke(evt.position, this);
            evt.StopPropagation();
        } 

        public void Set(int index, ItemScriptableObject item)
        {
            Index = index;
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