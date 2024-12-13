using System.Collections;
using Characters.Services;
using Characters.Views;

namespace Characters.Controllers
{
    public class PlayerController
    {
        private readonly PlayerService _playerService;
        private readonly StatsView _statsView;

        public PlayerController(StatsView statsView, PlayerService playerService)
        {
            _playerService = playerService;
            _statsView = statsView;
        }

        public IEnumerator Initialize()
        {
            var playerStats = _playerService.GetPlayerStats();
            yield return _statsView.Initialize(playerStats);

            _playerService.OnPlayerStatsChanged += _statsView.RefreshPlayerStat;
        }
        
        // Change Stat
        // _playerService.ChangeStat
        // _statsView.RefreshPlayerStat(Stat, int)
    }
}