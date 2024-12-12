using Overworld.Controllers;
using Overworld.Models;
using Overworld.Services;
using Overworld.Views;
using UnityEngine;
using UnityEngine.UIElements;

namespace Overworld
{
    public class Overworld : MonoBehaviour
    {
        [SerializeField] private UIDocument uiDocument;
        private OverworldController _overworldController;
        // Save Data to instantiate Overworld map + Event information
        
        private void Awake()
        {
            var locationsService = new LocationsService();
            var timePeriodService = new TimePeriodService(TimePeriod.Morning);
            var buttonView = new ButtonView(uiDocument);
            _overworldController = new OverworldController(buttonView, locationsService, timePeriodService);
            StartCoroutine(_overworldController.Initialize());
            
            DontDestroyOnLoad(this);
        }
    }
}