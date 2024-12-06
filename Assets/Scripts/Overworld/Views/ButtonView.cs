using UnityEngine;
using UnityEngine.UIElements;

namespace Overworld.Controllers
{
    public class ButtonView : MonoBehaviour
    {
        public UIDocument document;
        private VisualElement _root;

        private void Awake()
        {
            document = GetComponent<UIDocument>();
            _root = document.rootVisualElement;
            
            var buttonRowChildren = _root.Q("ButtonRow").Children();

            foreach (var buttonCol in buttonRowChildren)
            {
                SetupButtonEvent(buttonCol);
            }

            //_timePeriodButton.clicked += delegate { };
        }

        private void SetupButtonEvent(VisualElement buttonCol)
        {
            var button = buttonCol.Q<Button>();
            var pairName = button.name.Replace("Button", "");
            var element = _root.Q<VisualElement>($"{pairName}Box");
            
            button.clicked += delegate { OnButtonToggle(element); };
        }
        
        private static void OnButtonToggle(VisualElement uiElement) => 
            uiElement.style.display = uiElement.style.display == DisplayStyle.None 
                ? DisplayStyle.Flex 
                : DisplayStyle.None;
    }
}
