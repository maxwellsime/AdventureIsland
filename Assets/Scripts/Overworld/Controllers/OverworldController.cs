using Overworld.Models;
using Overworld.Services;
using Overworld.Views;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class OverworldController
{
    private static TimePeriodService _timePeriodService;
    private LocationsService _locationsService;
    
    public OverworldController(
        UIDocument uiDocument,
        TimePeriod timePeriod
    ){
        ButtonView.InitializeView(uiDocument);

        _timePeriodService = new TimePeriodService(timePeriod);
        _locationsService = new LocationsService();
        
        _timePeriodService.TimePeriodForwarded += UpdateSceneWithTimePeriod;
    }

    private static void UpdateSceneWithTimePeriod(string sceneName) => SceneManager.LoadScene(sceneName);
    
    public static void ProgressTimePeriod() => _timePeriodService.ForwardTimePeriod();
}
