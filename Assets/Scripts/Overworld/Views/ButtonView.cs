using System.Collections.Generic;
using System.Linq;
using UnityEngine.UIElements;

namespace Overworld.Views
{
    public static class ButtonView
    {
        private static VisualElement _root;
        private static List<VisualElement> _buttonRowElements = new();
        
        public static void InitializeView(UIDocument document)
        {
            _root = document.rootVisualElement;
            var timeDial = _root.Q<Button>("TimeDial");

            timeDial.clicked += OverworldController.ProgressTimePeriod;
            
            ButtonRowSetup();
        }

        private static void ButtonRowSetup()
        {
            var buttonRowChildren = _root.Q("ButtonRow").Children();

            foreach (var buttonCol in buttonRowChildren)
            {
                var button = buttonCol.Q<Button>();
                var pairName = button.name.Replace("Button", "");
                var element = _root.Q<VisualElement>($"{pairName}Box");
                _buttonRowElements.Add(element);
                
                button.clicked += delegate { OnButtonClick(element); };
            }
        }

        private static void OnButtonClick(VisualElement clickedButtonElement)
        {
            foreach (var element in _buttonRowElements.Where(element => clickedButtonElement != element))
            {
                element.style.display = DisplayStyle.None;
            }
            
            ToggleButtonElementDisplay(clickedButtonElement);
        }
        
        private static void ToggleButtonElementDisplay(VisualElement element) => 
            element.style.display = element.style.display == DisplayStyle.None 
                ? DisplayStyle.Flex 
                : DisplayStyle.None;
    }
}
