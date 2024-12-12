using System.Collections;
using Overworld.Services;
using Overworld.Views;
using UnityEngine.SceneManagement;

namespace Overworld.Controllers
{
    public class OverworldController
    {
        private LocationsService _locationsService;
        private static TimePeriodService _timePeriodService;
        private readonly ButtonView _buttonView;

        public OverworldController(
            ButtonView buttonView,
            LocationsService locationsService,
            TimePeriodService timePeriodService
        ){
            _buttonView = buttonView;
            _locationsService = locationsService;
            _timePeriodService = timePeriodService;
        }

        public IEnumerator Initialize()
        {
            yield return _buttonView.Initialize();
        
            _timePeriodService.TimePeriodForwarded += UpdateSceneWithTimePeriod;
        }

        private static void UpdateSceneWithTimePeriod(string sceneName) => SceneManager.LoadScene(sceneName);
    
        public static void ProgressTimePeriod() => _timePeriodService.ForwardTimePeriod();
    }
}
