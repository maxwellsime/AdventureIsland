using Inventory;
using JetBrains.Annotations;
using UnityEngine;

namespace UI
{
    public class ItemSlot : MonoBehaviour
    {
        [CanBeNull] public ItemScriptableObject item;
        private SpriteRenderer _spriteRenderer;
    
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();

            if (item != null)
            {
                UpdateSpriteRenderer();
            }
        }

        public void UpdateItem(ItemScriptableObject newItem)
        {
            item = newItem;
            UpdateSpriteRenderer();
        }

        private void UpdateSpriteRenderer()
        {
            _spriteRenderer.sprite = item.icon;
            _spriteRenderer.transform.localScale = new Vector3(0.4f, 0.4f, 0);    
        }
    }
}
