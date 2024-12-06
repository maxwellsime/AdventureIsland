using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using Utilities;

namespace Inventory.Views
{
    public class InventoryView : MonoBehaviour
    {
        public InventorySlot[] Slots;
        [SerializeField] private UIDocument document;
        
        private VisualElement _root;
        private VisualElement _container;
        private static VisualElement _inventoryDragIcon;

        private static bool _draggingItem;
        private static InventorySlot _interactingSlot;
        
        public event Action<InventorySlot, InventorySlot> OnDrop;

        public void InitializeView(int size = 30)
        {
            Slots = new InventorySlot[size];
            Debug.Log($"Slots initialized as {Slots.Length}");
            _root = document.rootVisualElement;
            _container = _root.Q("InventoryBox");

            for (var i = 0; i < size; i++)
            {
                var slot = _container.CreateChild<InventorySlot>("InventorySlot");
                Slots[i] = slot;
            }
            
            _inventoryDragIcon = _root.CreateChild("InventoryDragIcon");
            _inventoryDragIcon.BringToFront();
            _inventoryDragIcon.RegisterCallback<PointerMoveEvent>(OnPointerMove);
            _inventoryDragIcon.RegisterCallback<PointerUpEvent>(OnPointerUp);

            foreach (var slot in Slots)
            {
                slot.OnStartDrag += OnPointerDown;
            }
        }

        private static void OnPointerDown(Vector2 position, InventorySlot slot)
        {
            Debug.Log("OnPointerDown called");
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
            Debug.Log("OnPointerUp called");
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