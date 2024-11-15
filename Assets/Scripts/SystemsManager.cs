using System.Collections.Generic;
using UnityEngine;

public class SystemsManager : MonoBehaviour
{
    private readonly Dictionary<string, Vector3> LocationPositionDictionary = new();
    private TimePeriod _currentTimePeriod;

    private void Start()
    {
        var locationGameObjects = GameObject.FindGameObjectsWithTag("Location");
        foreach (var location in locationGameObjects)
        {
            LocationPositionDictionary.Add(location.name, location.transform.position);
        }

        _currentTimePeriod = TimePeriod.Morning;
    }
    
    public TimePeriod GetCurrentTimePeriod() => _currentTimePeriod;

    public void ChangeTimePeriod()
    {
        var newTimePeriodInt = (int)_currentTimePeriod + 1;
        _currentTimePeriod = newTimePeriodInt > 3 ? TimePeriod.Morning : (TimePeriod)newTimePeriodInt;
    }

    public Vector3 GetLocationPosition(string locationName) => LocationPositionDictionary[locationName];
}

public enum TimePeriod
{
    Morning,
    Midday,
    Afternoon, 
    Evening
}
