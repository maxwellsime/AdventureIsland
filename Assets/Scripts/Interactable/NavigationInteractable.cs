using Controllers;
using UnityEngine;

namespace UI
{
    public class NavigationInteractable : MonoBehaviour
    {
        [SerializeField]
        private string designatedLocationKey;
        private Vector3 _designatedLocationVector;
        private SystemsManager _systemsManager;
    
        private void Start()
        {
            _systemsManager = GameObject.Find("SystemsManager").GetComponent<SystemsManager>();
        }

        private void OnMouseDown()
        {
            var newPosition = _systemsManager.GetLocationPosition(designatedLocationKey);
            Camera.main.transform.position = new Vector3(newPosition.x, newPosition.y, -1);
        }
    }
}
