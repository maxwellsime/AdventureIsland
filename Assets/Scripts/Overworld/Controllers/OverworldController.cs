using Overworld.Models;
using Overworld.Services;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverworldController : MonoBehaviour
{
    private TimePeriodService timePeriodService;
    private LocationsService locationsService;

    private void OnEnable()
    {
        timePeriodService = new TimePeriodService(TimePeriod.Morning);
        timePeriodService.TimePeriodForwarded += UpdateSceneWithTimePeriod;
        
        locationsService = new LocationsService();
        
        DontDestroyOnLoad(this);
    }

    private static void UpdateSceneWithTimePeriod(string sceneName) => SceneManager.LoadScene(sceneName);
}
