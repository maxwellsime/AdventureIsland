using System.Collections.Generic;
using Characters.Models;

namespace Characters.Services
{
    public class PlayerService
    {
        private readonly Dictionary<PlayerStatsEnum, int> _playerStats = new();
        
        public int ChangeStat(PlayerStatsEnum stat, int statDelta) => _playerStats[stat] += statDelta;
        
        public int GetStat(PlayerStatsEnum stat) => _playerStats[stat];

        public string GetStats() => _playerStats.ToString();
    }
}