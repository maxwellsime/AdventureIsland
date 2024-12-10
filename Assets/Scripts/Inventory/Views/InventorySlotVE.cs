using System;
using UnityEngine;
using UnityEngine.UIElements;
using Utilities;

namespace Inventory.Views
{
    public class InventorySlot : VisualElement
    {
        public int Index => parent.IndexOf(this);
        public int ItemId { get; private set; }
        public Texture2D ItemTexture;
        private string _itemQuantity;
        private readonly Image _icon;
        private readonly Label _amountLabel;

        public event Action<Vector2, InventorySlot> OnStartDrag = delegate { };
        
        public InventorySlot()
        {
            _icon = this.CreateChild<Image>("InventorySlotImage");
            _amountLabel = this.CreateChild<Label>("InventorySlotAmount");
            RegisterCallback<PointerDownEvent>(OnPointerDown);
        }
        
        public void Set(int id, Texture2D icon, int quantity)
        {
            ItemId = id;
            _itemQuantity = quantity.ToString();
            ItemTexture = icon;
            
            _icon.image = icon;
            _amountLabel.text = quantity > 1 ? _itemQuantity : string.Empty;
        }

        private void OnPointerDown(PointerDownEvent evt)
        {
            if (evt.button != 0 || _icon.image == null) return;
            
            OnStartDrag.Invoke(evt.position, this);
            evt.StopPropagation();
        } 
        
        public void Remove()
        {
            _icon.image = null;
            _amountLabel.text = string.Empty;
        }

        public void ToggleItemVisibility()
        {
            _icon.image = _icon.image == null ? ItemTexture : null;
            _amountLabel.text = _amountLabel.text == string.Empty ? _itemQuantity : string.Empty;
        }
    }
}