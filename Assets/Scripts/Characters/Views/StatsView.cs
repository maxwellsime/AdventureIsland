using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Characters.Models;
using UnityEngine.UIElements;
using Utilities;

namespace Characters.Views
{
    public class StatsView
    {
        //public NPCStatVE[] NPCStats;
        private VisualElement _container;
        private readonly VisualElement _root;
        
        public StatsView(UIDocument uiDocument)
        {
            _root = uiDocument.rootVisualElement;
        }

        public IEnumerator Initialize(Dictionary<PlayerStatsEnum, int> playerStats)
        {
            _container = _root.Q<VisualElement>("StatsBox");
            CreatePlayerStats(playerStats);
            
            yield return null;
        }

        private void CreatePlayerStats(Dictionary<PlayerStatsEnum, int> playerStats)
        {
            var playerColumn = _container.Children().First();
            
            foreach (var playerStat in playerStats)
            {
                playerColumn.CreateChild<Label>("PlayerStatsLabel")
                        .text = CreatePlayerStatsLabelString(playerStat.Key, playerStat.Value);
            }
        }
        
        // private void CreateNPCStats(List<NPCharacter> npcs)

        public void RefreshPlayerStat(PlayerStatsEnum stat, int value)
        {
        }

        //public async Task<> RefreshNPCStatAsync()
        
        private string CreatePlayerStatsLabelString(PlayerStatsEnum stat, int value) =>
            $"{stat.ToString().ToUpper()}: {value.ToString()}";
    }
}