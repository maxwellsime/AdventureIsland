using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;
using Utilities;

namespace Inventory.Views
{
    public class InventoryView
    {
        public InventorySlot[] Slots;
        private VisualElement _container;
        private static Label _inventoryAddItemPopup;
        private static VisualElement _inventoryDragIcon;
        private static bool _draggingItem;
        private static InventorySlot _interactingSlot;
        private readonly VisualElement _root;
        
        public event Action<InventorySlot, InventorySlot> OnDrop;

        public InventoryView(UIDocument uiDocument)
        {
            _root = uiDocument.rootVisualElement;
        }

        public IEnumerator Initialize(int size = 30)
        {
            Slots = new InventorySlot[size];
            _container = _root.Q("InventoryBox");

            for (var i = 0; i < size; i++)
            {
                var slot = _container.CreateChild<InventorySlot>("InventorySlot");
                Slots[i] = slot;
            }

            _inventoryAddItemPopup = _root.CreateChild<Label>("InventoryItemPopup");
            _inventoryAddItemPopup.BringToFront();
            
            _inventoryDragIcon = _root.CreateChild("InventoryDragIcon");
            _inventoryDragIcon.BringToFront();
            _inventoryDragIcon.RegisterCallback<PointerMoveEvent>(OnPointerMove);
            _inventoryDragIcon.RegisterCallback<PointerUpEvent>(OnPointerUp);

            foreach (var slot in Slots)
            {
                slot.OnStartDrag += OnPointerDown;
            }

            yield return null;
        }

        public static async void ItemPopup(string itemName, int quantity)
        {
            _inventoryAddItemPopup.text = $"{quantity} x {itemName} added to inventory.";
            _inventoryAddItemPopup.style.visibility = Visibility.Visible;
            await Task.Delay(1000);
            _inventoryAddItemPopup.style.visibility = Visibility.Hidden;
        }

        private static void OnPointerDown(Vector2 position, InventorySlot slot)
        {
            _draggingItem = true;
            _interactingSlot = slot;
            
            SetDragIconPosition(position);
            _inventoryDragIcon.style.backgroundImage = _interactingSlot.ItemTexture;
            _inventoryDragIcon.style.visibility = Visibility.Visible;
            _interactingSlot.ToggleItemVisibility();
        }

        private static void OnPointerMove(PointerMoveEvent evt)
        {
            if (!_draggingItem) return;
            
            SetDragIconPosition(evt.position);
        }

        private void OnPointerUp(PointerUpEvent evt)
        {
            if(!_draggingItem) return;
            
            var closestSlot = Slots
                .Where(slot => slot.worldBound.Overlaps(_inventoryDragIcon.worldBound))
                .OrderBy(slot => Vector2.Distance(slot.worldBound.position, _inventoryDragIcon.worldBound.position))
                .FirstOrDefault();

            if (closestSlot != null)
            {
                OnDrop?.Invoke(_interactingSlot, closestSlot);
            }
            else
            {
                _interactingSlot.ToggleItemVisibility();
            }
            
            _draggingItem = false;
            _interactingSlot = null;
            _inventoryDragIcon.style.visibility = Visibility.Hidden;
        }
        
        private static void SetDragIconPosition(Vector2 position)
        {
            _inventoryDragIcon.style.top = position.y - _inventoryDragIcon.layout.height / 2;
            _inventoryDragIcon.style.left = position.x - _inventoryDragIcon.layout.width / 2;
        }
    }
}