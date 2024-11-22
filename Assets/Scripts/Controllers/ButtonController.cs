using System;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonController : MonoBehaviour
{
    public UIDocument document;
    private (Button, VisualElement) _stats;
    private (Button, VisualElement) _inventory;
    private (Button, VisualElement) _questLog;
    private VisualElement _root;

    private void Awake()
    {
        document = GetComponent<UIDocument>();
        _root = document.rootVisualElement;
    }

    void OnEnable()
    {
        _stats.Item1 = _root.Q<Button>("StatsButton");
        _stats.Item2 = _root.Q<VisualElement>("StatsBox");
        _stats.Item1.clicked += delegate { OnButtonToggle(_stats.Item2); };

        _inventory.Item1 = _root.Q<Button>("InventoryButton");
        _inventory.Item2 = _root.Q<VisualElement>("InventoryBox");
        _inventory.Item1.clicked += delegate { OnButtonToggle(_inventory.Item2); };

        _questLog.Item1 = _root.Q<Button>("QuestLogButton");
        _questLog.Item2 = _root.Q<VisualElement>("QuestLogBox");
        _questLog.Item1.clicked += delegate { OnButtonToggle(_questLog.Item2); };
    }

    // Potentially look into Visibility and Enabled if necessary
    private void OnButtonToggle(VisualElement uiElement) => 
        uiElement.style.display = uiElement.style.display == DisplayStyle.None 
            ? DisplayStyle.Flex 
            : DisplayStyle.None;
}
