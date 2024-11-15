using UnityEngine;

namespace Inventory
{
    public class ItemInteractable : MonoBehaviour
    {
        public ItemScriptableObject itemScriptableObject;
        private SystemsManager _systemsManager;

        private void Start()
        {
            _systemsManager = GameObject.Find("SystemsManager").GetComponent<SystemsManager>();
        }

        private void OnMouseDown()
        {
            _systemsManager.Inventory.AddItem(itemScriptableObject);
        }
    }
}
