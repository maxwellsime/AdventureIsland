using Characters.Controllers;
using Characters.Services;
using Characters.Views;
using UnityEngine;
using UnityEngine.UIElements;

namespace Characters
{
    public class Characters : MonoBehaviour
    {
        [SerializeField] private UIDocument uiDocument;
        private PlayerController _playerController;
    
        private void Awake()
        {
            var statsView = new StatsView(uiDocument);
            var playerService = new PlayerService();
            _playerController = new PlayerController(statsView, playerService);
            StartCoroutine(_playerController.Initialize());
        }
    }
}