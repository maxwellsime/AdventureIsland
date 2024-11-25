using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using Utilities;

namespace UI
{
    public class InventoryView : MonoBehaviour
    {
        public InventorySlot[] slots;
        [SerializeField] protected UIDocument document;
        protected VisualElement root;
        protected VisualElement container;

        public void InitializeView(int size = 20)
        {
            slots = new InventorySlot[size];
            Debug.Log($"Slots initialized as {slots.Length}");
            root = document.rootVisualElement;
            container = root.Q("InventoryBox");

            for (var i = 0; i < size; i++)
            {
                var slot = container.CreateChild<InventorySlot>("InventorySlot");
                slots[i] = slot;
            }
        }
    }
}