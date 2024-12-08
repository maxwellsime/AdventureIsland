using UnityEngine.UIElements;

namespace Overworld.Views
{
    public class ButtonView
    {
        private readonly VisualElement _root;
        
        public ButtonView(UIDocument document)
        {
            _root = document.rootVisualElement;
            var timeDial = _root.Q<Button>("TimeDial");

            timeDial.clicked += OverworldController.ProgressTimePeriod;
            
            ButtonRowSetup();
        }

        private void ButtonRowSetup()
        {
            var buttonRowChildren = _root.Q("ButtonRow").Children();

            foreach (var buttonCol in buttonRowChildren)
            {
                var button = buttonCol.Q<Button>();
                var pairName = button.name.Replace("Button", "");
                var element = _root.Q<VisualElement>($"{pairName}Box");
            
                button.clicked += delegate { OnButtonToggle(element); };
            }
        }
        
        private static void OnButtonToggle(VisualElement uiElement) => 
            uiElement.style.display = uiElement.style.display == DisplayStyle.None 
                ? DisplayStyle.Flex 
                : DisplayStyle.None;
    }
}
