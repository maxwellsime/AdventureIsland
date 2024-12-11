using UnityEngine;

namespace Utilities
{
    public class SystemsManager : MonoBehaviour
    {
        private static SystemsManager _instance;
        public static SystemsManager Instance
        {
            get
            {
                if (_instance) return _instance;
                var prefab = Resources.Load<GameObject>("SystemsManager");
                var inScene = Instantiate(prefab);
                _instance = inScene.GetComponentInChildren<SystemsManager>();
                if (!_instance) _instance = inScene.AddComponent<SystemsManager>();

                DontDestroyOnLoad(_instance.transform.root.gameObject);
                return _instance;
            }
        }
    }
}
