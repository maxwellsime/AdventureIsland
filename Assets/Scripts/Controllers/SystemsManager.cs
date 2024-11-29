using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

namespace Controllers
{
    public class SystemsManager : MonoBehaviour
    {
        [SerializeField] private TimePeriod currentTimePeriod;
        private readonly Dictionary<string, Vector3> _locationPositionDictionary = new(); // WILL NEED TO BE RECALCULATED UPON NEW AREA DISCOVERED
    

        private void Awake()
        {
            var locationGameObjects = GameObject.FindGameObjectsWithTag("Location");
            foreach (var location in locationGameObjects)
            {
                _locationPositionDictionary.Add(location.name, location.transform.position);
            }
            Debug.Log(_locationPositionDictionary.Count);
        
            DontDestroyOnLoad(this); // Causes potential problems with multiple scenes creating a unique one. Potential singleton?
        }
    
        public TimePeriod GetCurrentTimePeriod() => currentTimePeriod;

        public void ForwardTimePeriod()
        {
            var newTimePeriodInt = (int)currentTimePeriod + 1;
            currentTimePeriod = newTimePeriodInt > 3 ? TimePeriod.Morning : (TimePeriod)newTimePeriodInt;
            UpdateTimePeriodScene();
        }

        public Vector3 GetLocationPosition(string locationName) => _locationPositionDictionary[locationName];

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
}