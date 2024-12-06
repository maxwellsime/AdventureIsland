using System;
using UnityEngine;

namespace Overworld.Models
{
    public class NavigationArrowGameObject : MonoBehaviour
    {
        [SerializeField]
        private string designatedLocationKey;

        public static event Action<string> OnClick;

        private void OnMouseDown() => OnClick?.Invoke(designatedLocationKey);
    }
}
