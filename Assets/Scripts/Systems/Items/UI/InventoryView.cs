using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using Utilities;

namespace UI
{
    public class InventoryView : MonoBehaviour
    {
        public InventorySlot[] Slots;
        [SerializeField] protected UIDocument document;
        
        private VisualElement _root;
        private VisualElement _container;
        private static VisualElement _inventoryDragIcon;

        private static bool _beingDragged;
        private static InventorySlot _originalSlot;
        
        public event Action<InventorySlot, InventorySlot> OnDrop;

        public void InitializeView(int size = 20)
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
            _beingDragged = true;
            _originalSlot = slot;
            
            SetDragIconPosition(position);
            _inventoryDragIcon.style.backgroundImage = _originalSlot.Item.icon.texture;
            _originalSlot.Icon.image = null;
            _originalSlot.AmountLabel.visible = false;
            _inventoryDragIcon.style.visibility = Visibility.Visible;
        }

        private static void OnPointerMove(PointerMoveEvent evt)
        {
            Debug.Log("OnPointerMove called");
            if (!_beingDragged) return;
            
            SetDragIconPosition(evt.position);
        }

        private void OnPointerUp(PointerUpEvent evt)
        {
            Debug.Log("OnPointerUp called");
            if(!_beingDragged) return;
            
            var closestSlot = Slots
                .Where(slot => slot.worldBound.Overlaps(_inventoryDragIcon.worldBound))
                .OrderBy(slot => Vector2.Distance(slot.worldBound.position, _inventoryDragIcon.worldBound.position))
                .FirstOrDefault();

            if (closestSlot != null)
            {
                OnDrop?.Invoke(_originalSlot, closestSlot);
            }
            else
            {
                _originalSlot.Icon.image = _originalSlot.Item.icon.texture;
            }
            
            _beingDragged = false;
            _originalSlot = null;
            _inventoryDragIcon.style.visibility = Visibility.Hidden;
        }
        
        private static void SetDragIconPosition(Vector2 position)
        {
            _inventoryDragIcon.style.top = position.y - _inventoryDragIcon.layout.height / 2;
            _inventoryDragIcon.style.left = position.x - _inventoryDragIcon.layout.width / 2;
        }
    }
}