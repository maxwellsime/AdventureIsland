using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

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
                Debug.Log("New Slot");
                var slot = new InventorySlot();
                container.Add(slot);
                slots[i] = slot;
            }
        }
    }
}