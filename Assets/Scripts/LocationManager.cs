using UnityEngine;

public class LocationManager : MonoBehaviour
{
    private GameObject _background;
    private SystemsManager _systemsManager;
    
    private void Start()
    {
        _systemsManager = GameObject.Find("SystemsManager").GetComponent<SystemsManager>();
        _background = gameObject.transform.GetChild(0).gameObject;
    }

    private void ChooseBackgroundSprite()
    {
        
    }
}
