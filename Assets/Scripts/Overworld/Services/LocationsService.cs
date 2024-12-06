using System.Collections.Generic;
using Overworld.Models;
using UnityEngine;

namespace Overworld.Services
{
    public class LocationsService
    {
        private readonly Dictionary<string, Vector3> _locationPositionDictionary = new();
        // Utilize discovered boolean within LocationGO

        public LocationsService()
        {
            UpdateLocationDictionary();
            NavigationArrowGameObject.OnClick += CameraToLocation;
        }
        
        private void UpdateLocationDictionary()
        {
            var locationGameObjects = GameObject.FindGameObjectsWithTag("Location");
            foreach (var location in locationGameObjects)
            {
                _locationPositionDictionary.Add(location.name, location.transform.position);
            }
            
            Debug.Log($"Number of locations: {_locationPositionDictionary.Count}");
        }

        private void CameraToLocation(string locationKey)
        {
            var locationPosition = _locationPositionDictionary[locationKey];
            Camera.main.transform.position = new Vector3(locationPosition.x, locationPosition.y, -1);
        }
    }
}
