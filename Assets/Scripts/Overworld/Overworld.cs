using Overworld.Models;
using Overworld.Services;
using Overworld.Views;
using UnityEngine;
using UnityEngine.UIElements;

namespace Overworld
{
    public class Overworld : MonoBehaviour
    {
        [SerializeField] private UIDocument overworldUIDocument;
        private OverworldController _overworldController;
        // Save Data to instantiate Overworld map + Event information
        
        private void OnEnable()
        {
            _overworldController = new OverworldController(
                new LocationsService(),
                new TimePeriodService(TimePeriod.Morning),
                new ButtonView(overworldUIDocument)
            );
            
            DontDestroyOnLoad(this);
        }
    }
}