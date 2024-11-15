using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class SystemsManager : MonoBehaviour
{
    [SerializeField]
    private TimePeriod currentTimePeriod;
    private readonly Dictionary<string, Vector3> LocationPositionDictionary = new();

    private void Start()
    {
        var locationGameObjects = GameObject.FindGameObjectsWithTag("Location");
        foreach (var location in locationGameObjects)
        {
            LocationPositionDictionary.Add(location.name, location.transform.position);
        }
        
        Debug.Log(LocationPositionDictionary.Count);
    }
    
    public TimePeriod GetCurrentTimePeriod() => currentTimePeriod;

    public void ForwardTimePeriod()
    {
        var newTimePeriodInt = (int)currentTimePeriod + 1;
        currentTimePeriod = newTimePeriodInt > 3 ? TimePeriod.Morning : (TimePeriod)newTimePeriodInt;
        UpdateTimePeriodScene();
    }

    public Vector3 GetLocationPosition(string locationName) => LocationPositionDictionary[locationName];

    private void UpdateTimePeriodScene()
    {
        switch((int)currentTimePeriod)
        {
            case 0: 
                SceneManager.LoadScene("OverworldMorning");
                break;
            case 1: 
                //SceneManager.LoadScene("OverworldMorning");
                break;            
            case 2: 
                SceneManager.LoadScene("OverworldNight");
                break;
            case 3: 
                //SceneManager.LoadScene("OverworldNight");
                break;
        }   
    }
}

public enum TimePeriod
{
    Morning,
    Midday,
    Afternoon, 
    Night
}
