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

        public IEnumerator InitializeView(int size = 20)
        {
            slots = new InventorySlot[size];
            root = document.rootVisualElement;
            container = root.Q("InventoryBox");

            for (int i = 0; i < size; i++)
            {
                var slot = new InventorySlot();
                container.Add(slot);
            }

            yield return null;
        }
    }
}