using System;
using UnityEngine;

namespace Inventory.Models
{
    public class ItemGameObject : MonoBehaviour
    {
        [SerializeField] private ItemScriptableObject itemScriptableObject;
        [SerializeField] private int quantity;
        
        public static event Action<ItemScriptableObject, int> OnClick;

        private void OnMouseDown()
        {
            OnClick?.Invoke(itemScriptableObject, quantity);
            Destroy(gameObject);
        }
    }
}
