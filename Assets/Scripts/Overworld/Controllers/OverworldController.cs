using Overworld.Controllers;
using Overworld.Services;
using UnityEngine.SceneManagement;

public class OverworldController
{
    private static TimePeriodService _timePeriodService;
    private LocationsService _locationsService;
    private ButtonView _buttonView;
    
    public OverworldController(
        LocationsService locationsService,
        TimePeriodService timePeriodService,
        ButtonView buttonView
    ){
        _timePeriodService = timePeriodService;
        _locationsService = locationsService;
        _buttonView = buttonView;
        
        _timePeriodService.TimePeriodForwarded += UpdateSceneWithTimePeriod;
    }

    private static void UpdateSceneWithTimePeriod(string sceneName) => SceneManager.LoadScene(sceneName);
    
    public static void ProgressTimePeriod() => _timePeriodService.ForwardTimePeriod();
}
