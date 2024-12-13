using System;
using System.Collections.Generic;
using Characters.Models;

namespace Characters.Services
{
    public class PlayerService
    {
        private readonly Dictionary<PlayerStatsEnum, int> _playerStats;
        
        public event Action<PlayerStatsEnum, int> OnPlayerStatsChanged;
        
        public PlayerService() //Intake saved data
        {
            _playerStats = new Dictionary<PlayerStatsEnum, int>();

            // if saved data does not exist then initializestats
            InitializeStats();
        }

        public int ChangeStat(PlayerStatsEnum stat, int statDelta)
        {
            _playerStats[stat] += statDelta;
            OnPlayerStatsChanged?.Invoke(stat, _playerStats[stat]);
            
            return _playerStats[stat];
        }

        public int GetStat(PlayerStatsEnum stat) => _playerStats[stat];

        public Dictionary<PlayerStatsEnum, int> GetPlayerStats() => _playerStats;

        private void InitializeStats()
        {
            foreach (PlayerStatsEnum stat in Enum.GetValues(typeof(PlayerStatsEnum)))
            {
                _playerStats.Add(stat, 1);
            }
        }
    }
}