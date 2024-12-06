using UnityEngine;

namespace Overworld.Models
{
    public class LocationGameObject : MonoBehaviour
    {
        [SerializeField] private Sprite backgroundSprite;
        public bool discovered;
    
        private void Start()
        {
            gameObject.transform.GetChild(0).gameObject.GetComponentInChildren<SpriteRenderer>().sprite = backgroundSprite;
        }
    }
}
