using UnityEngine;

public class TimeDial : MonoBehaviour
{
    private SystemsManager _systemsManager;
    
    private void Start()
    {
        _systemsManager = GameObject.Find("SystemsManager").GetComponent<SystemsManager>();
    }

    private void OnMouseDown()
    {
        _systemsManager.ForwardTimePeriod();        
    }
}
