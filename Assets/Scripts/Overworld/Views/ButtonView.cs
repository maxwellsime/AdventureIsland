using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Overworld.Controllers;
using UnityEngine.UIElements;

namespace Overworld.Views
{
    public class ButtonView
    {
        private readonly VisualElement _root;
        private readonly List<VisualElement> _buttonRowElements;

        public ButtonView(UIDocument uiDocument)
        {
            _root = uiDocument.rootVisualElement;
            _buttonRowElements = new List<VisualElement>();
        }
        
        public IEnumerator Initialize()
        {
            var timeDial = _root.Q<Button>("TimeDial");

            timeDial.clicked += OverworldController.ProgressTimePeriod;
            
            ButtonRowSetup();

            yield return null;
        }

        private void ButtonRowSetup()
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

        private void OnButtonClick(VisualElement clickedButtonElement)
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
